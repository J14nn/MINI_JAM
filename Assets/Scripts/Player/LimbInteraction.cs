using UnityEngine;

public class LimbInteraction : MonoBehaviour
{
    [SerializeField] private float itemGrabReach = 1f;
    [SerializeField] private Transform itemPosition;
    [SerializeField] private LayerMask interactableLayer;

    private PickableItem heldItem;

    private void Update()
    {
        MoveItem();
    }

    public bool TryToInteract()
    {
        if (heldItem)
        {
            heldItem = null;
            return true;
        }
        else
        {
            Collider[] hits = Physics.OverlapSphere(itemPosition.position, itemGrabReach, interactableLayer);

            if (hits != null && hits.Length > 0)
            {
                if (hits[0].transform.TryGetComponent(out PickableItem pickable))
                {
                    heldItem = pickable;
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