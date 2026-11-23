using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class LimbSelection : MonoBehaviour
{
    public BodyPart selectedPart;

    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    private void Update()
    {
        if (Globals.hasWon) return;

        UpdateCursor();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SelectLimb();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
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
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, playerLayer))
        {
            selectedPart = hit.transform.GetComponentInParent<BodyPart>();
        }
    }

    private void MoveSelectedLimb()
    {
        if (selectedPart)
        {
            selectedPart.Move();
        }
        else
        {
            Globals.soundManager.StopChainMoving();
        }
    }

    private void UpdateCursor()
    {
        Vector3 pos = Mouse.current.position.ReadValue();
        if (pos.x < 0f || pos.x > Screen.width || pos.y < 0f || pos.y > Screen.height || !Application.isFocused) return;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if ((!selectedPart && Physics.Raycast(ray, out RaycastHit _, float.MaxValue, playerLayer))
            || (selectedPart && selectedPart.limbInteraction && selectedPart.limbInteraction.CanPickUpItem(out PickableItem _)
            || (selectedPart && selectedPart.limbInteraction && selectedPart.limbInteraction.CanInteractWithNearInteractable())))
        {
            Cursor.SetCursor(Globals.cursorInteraction, new Vector2(16, 16), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(Globals.cursorDefault, new Vector2(16, 16), CursorMode.ForceSoftware);
        }
    }
}