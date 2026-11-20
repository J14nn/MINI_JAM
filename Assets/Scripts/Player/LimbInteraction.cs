using UnityEngine;

public class LimbInteraction : MonoBehaviour
{
    [SerializeField] private float itemGrabReach = 1f;
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private Transform itemPosition;
    [SerializeField] private LayerMask interactableLayer;

    private PickableItem heldItem;

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
        if (heldItem)
        {
            if (heldItem is Addchain)
            {
                Collider[] hits = Physics.OverlapSphere(itemPosition.position, interactionRange, interactableLayer);

                if (hits != null && hits.Length > 0)
                {
                    foreach (Collider hit in hits)
                    {
                        if (hit.transform.TryGetComponent(out Winch winch))
                        {
                            winch.AddChain();
                            Destroy(heldItem.gameObject);
                            heldItem = null;
                            return true;
                        }
                    }
                }
            }
            else
            {
                heldItem.Drop();
                heldItem = null;
                return true;
            }
        }
        else
        {
            Collider[] hits = Physics.OverlapSphere(itemPosition.position, itemGrabReach, interactableLayer);

            if (hits != null && hits.Length > 0)
            {
                PickableItem pickable = hits[0].transform.GetComponentInParent<PickableItem>();
                if (pickable)
                {
                    heldItem = pickable;
                    heldItem.Pickup();
                    return true;
                }
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