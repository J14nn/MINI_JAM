using UnityEngine;

public class LimbSelection : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private LimbMover selectedLimb;

    private void Update()
    {
        if (Input.player.Interact.WasPressedThisFrame())
        {
            Interact();
        }
        MoveSelectedLimb();
    }

    private void MoveSelectedLimb()
    {
        if (!selectedLimb) return;

        selectedLimb.MoveLimb();
    }

    private void Interact()
    {
        if (!selectedLimb)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, playerLayer))
            {
                selectedLimb = hit.transform.GetComponentInParent<LimbMover>();
            }
        }
        else if (selectedLimb && (!selectedLimb.limbInteraction || !selectedLimb.limbInteraction.TryToInteract()))
        {
            selectedLimb = null;
        }
    }
}