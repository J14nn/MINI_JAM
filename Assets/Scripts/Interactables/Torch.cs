using System.Threading.Tasks;
using UnityEngine;

public class Torch : PickableItem
{
    [Tooltip("For how long the player should hold torch before dropping it.")]
    [SerializeField] private float holdTime = 1f;
    [SerializeField] private Transform groundTransform;
    [SerializeField] private CorpseFire corpseFire;

    public override async void Pickup()
    {
        await Awaitable.WaitForSecondsAsync(holdTime);

        limbInteraction.heldItem = null;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform == groundTransform)
        {
            corpseFire.StartFire();
        }
    }
}