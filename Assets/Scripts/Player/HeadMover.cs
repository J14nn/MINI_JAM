using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMover : BodyPart
{
    [SerializeField] private float maxYaw = 60f;
    [SerializeField] private float maxPitch = 40f;

    private void Start()
    {
        limbInteraction = GetComponent<LimbInteraction>();
    }

    public override void Move()
    {
        float depth = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector2 screenMouse = Mouse.current.position.ReadValue();
        Vector2 worldMouse = Camera.main.ScreenToWorldPoint(new Vector3(screenMouse.x, screenMouse.y, depth));
        Vector2 headPos = transform.position;
        Vector2 dir = (headPos - worldMouse).normalized;
        float multiplier = (headPos - worldMouse).magnitude / 5f;
        dir *= multiplier;

        float yaw = Mathf.Clamp(dir.x * maxYaw, -maxYaw, maxYaw);
        float pitch = Mathf.Clamp(-dir.y * maxPitch, -maxPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(-yaw, 0, pitch);
    }
}