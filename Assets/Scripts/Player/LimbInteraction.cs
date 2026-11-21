using System.Collections.Generic;
using System.Linq;
using Unity.Burst;
using UnityEngine;

public class LimbInteraction : MonoBehaviour
{
    public PickableItem heldItem;
    public Transform itemPosition;

    [SerializeField] private float itemGrabReach = 1f;
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private LayerMask interactableLayer;


    private void Update()
    {
        MoveItem();
        UpdateInteraction();
    }

    private void UpdateInteraction()
    {
        Collider[] hits = Physics.OverlapSphere(itemPosition.position, itemGrabReach, interactableLayer);

        if (hits != null && hits.Length > 0)
        {
            Lever lever = hits[0].transform.GetComponentInParent<Lever>();
            if (lever)
            {
                lever.PushDown();
            }
        }
    }

    public bool TryToInteract()
    {
        if (heldItem && TryToInteractWithHandItem())
        {
            return true;
        }
        else if (!heldItem && TryToPickupItem())
        {
            return true;
        }

        return false;
    }

    private bool TryToInteractWithHandItem()
    {
        if (heldItem is Addchain && IsInteractableNear(out Winch winch))
        {
            winch.AddChain(((Addchain)heldItem).lengthIncrease);
            Destroy(heldItem.gameObject);
            heldItem = null;
            return true;
        }
        else if (heldItem is KeyInteractable && IsInteractableNear(out LockedCompartment compartment))
        {
            compartment.Unlock();
            Destroy(heldItem.transform.parent.gameObject);
            heldItem = null;
            return true;
        }

        return false;
    }

    private bool IsInteractableNear<T>(out T interactable) where T : MonoBehaviour
    {
        Collider[] hits = Physics.OverlapSphere(itemPosition.position, interactionRange, interactableLayer);
        interactable = null;

        if (hits != null && hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (hit.transform.TryGetComponent(out interactable))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool TryToPickupItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, interactableLayer))
        {
            PickableItem pickable = hit.transform.GetComponentInParent<PickableItem>();

            if (Vector3.Distance(hit.point, itemPosition.position) > itemGrabReach)
            {
                return false;
            }

            if (pickable)
            {
                if (pickable.limbInteraction)
                {
                    pickable.limbInteraction.heldItem = null;
                    Player.limbSelection.SelectPartNextFrame(GetComponent<BodyPart>());
                }

                heldItem = pickable;
                heldItem.Pickup();
                pickable.limbInteraction = this;
                return true;
            }
        }

        return false;
    }

    private void MoveItem()
    {
        if (!heldItem) return;

        heldItem.transform.position = itemPosition.position;
    }
}