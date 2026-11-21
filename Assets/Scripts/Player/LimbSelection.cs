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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        BodyPart lastSelectedPart = selectedPart;
        if (selectedPart && (!selectedPart.limbInteraction || !selectedPart.limbInteraction.TryToInteract()))
        {
            selectedPart = null;
        }
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, playerLayer))
        {
            BodyPart newPart = hit.transform.GetComponentInParent<BodyPart>();
            if (newPart && newPart != lastSelectedPart)
            {
                selectedPart = newPart;
            }
        }
    }
}