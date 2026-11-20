using UnityEngine;

public class LimbSelection : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private BodyPart selectedPart;

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
        if (!selectedPart) return;

        selectedPart.Move();
    }

    private void Interact()
    {
        if (!selectedPart)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, playerLayer))
            {
                selectedPart = hit.transform.GetComponentInParent<BodyPart>();
            }
        }
        else if (selectedPart && (!selectedPart.limbInteraction || !selectedPart.limbInteraction.TryToInteract()))
        {
            selectedPart = null;
        }
    }
}