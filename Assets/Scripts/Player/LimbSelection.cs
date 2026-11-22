using System.Threading.Tasks;
using UnityEngine;

public class LimbSelection : MonoBehaviour
{
    [HideInInspector] public BodyPart selectedPart;

    [SerializeField] private LayerMask playerLayer;

    private void Update()
    {
        if (Input.player.MoveLimb.WasPressedThisFrame())
        {
            SelectLimb();
        }
        else if (Input.player.MoveLimb.WasReleasedThisFrame())
        {
            selectedPart = null;
        }

        MoveSelectedLimb();
    }

    public async void SelectPartNextFrame(BodyPart part)
    {
        await Awaitable.NextFrameAsync();
        await Awaitable.NextFrameAsync();
        selectedPart = part;
    }

    private void SelectLimb()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, playerLayer))
        {
            selectedPart = hit.transform.GetComponentInParent<BodyPart>();
        }
    }

    private void MoveSelectedLimb()
    {
        if (!selectedPart) return;

        selectedPart.Move();
    }
}