using UnityEngine;

public class LimbSelection : MonoBehaviour
{
    [HideInInspector] public BodyPart selectedPart;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private MainChain mainChain;

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
        mainChain.UpdateChainsAndLimbs();
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