using UnityEngine;

public class LimbInteraction : MonoBehaviour
{
    [HideInInspector] public LimbMover limbMover;
    public PickableItem heldItem;
    public Transform itemPosition;

    [SerializeField] private float itemGrabReach = 1f;
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private LayerMask interactableLayer;

    private BodyPart bodyPart;

    private void Start()
    {
        limbMover = GetComponent<LimbMover>();
        bodyPart = GetComponent<BodyPart>();
    }

    private void Update()
    {
        MoveItem();
        UpdateInteraction();

        if (Input.player.Interact.WasPressedThisFrame() && Globals.limbSelection.selectedPart == bodyPart)
        {
            TryToInteract();
        }
    }

    private void UpdateInteraction()
    {
        Collider[] hits = Physics.OverlapSphere(itemPosition.position, interactionRange, interactableLayer);

        if (hits != null && hits.Length > 0)
        {
            Lever lever = hits[0].transform.GetComponentInParent<Lever>();
            if (lever)
            {
                lever.PushDown();
            }
        }
    }

    public void TryToInteract()
    {
        if (heldItem)
        {
            TryToInteractWithHandItem();
        }
        else
        {
            TryToPickupItem();
        }
    }

    private void TryToInteractWithHandItem()
    {
        if (heldItem is KeyInteractable && IsInteractableNear(out LockedCompartment compartment))
        {
            compartment.Unlock();
            Destroy(heldItem.transform.parent.gameObject);
            heldItem = null;
            itemGrabReach = 4f;
        }
    }

    public bool CanInteractWithNearInteractable()
    {
        return heldItem is KeyInteractable && IsInteractableNear(out LockedCompartment _);
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

    private void TryToPickupItem()
    {
        if (CanPickUpItem(out PickableItem pickable))
        {
            Globals.soundManager.PlaySound(Globals.soundManager.pickUpItemClip, 0.6f);

            if (pickable.limbInteraction)
            {
                pickable.limbInteraction.heldItem = null;
                Globals.limbSelection.SelectPartNextFrame(GetComponent<BodyPart>());
            }

            heldItem = pickable;
            heldItem.Pickup();
            pickable.limbInteraction = this;
        }
    }

    private void MoveItem()
    {
        if (!heldItem) return;

        heldItem.transform.position = itemPosition.position;
    }

    public bool CanPickUpItem(out PickableItem pickable)
    {
        pickable = null;
        if (heldItem) return false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray, float.MaxValue, interactableLayer);

        foreach (RaycastHit hit in hits)
        {
            pickable = hit.transform.GetComponentInParent<PickableItem>();

            if (Vector3.Distance(hit.point, itemPosition.position) > itemGrabReach)
                continue;

            if (pickable)
            {
                if (!pickable.canBePickedByMouth && Globals.limbSelection.selectedPart is HeadMover)
                    continue;

                return true;
            }
        }

        return false;
    }
}