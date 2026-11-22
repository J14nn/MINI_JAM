using UnityEngine;

public class KeyInteractable : PickableItem
{
    [SerializeField] private SpringJoint joint;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Lever lever;

    private void Update()
    {
        MoveKeyToHand();
    }

    private void MoveKeyToHand()
    {
        if (!limbInteraction) return;

        transform.position = limbInteraction.itemPosition.position;
    }

    public override void Pickup()
    {
        lever.shouldRelease = false;
        Destroy(joint);
        Destroy(rb);
    }

    public override void Drop()
    {
        limbInteraction = null;
    }
}