using UnityEngine;

public class FireIron : PickableItem
{
    private void Update()
    {
        if (limbInteraction && limbInteraction.limbMover)
        {
            Vector3 handDir = limbInteraction.limbMover.limbTarget.position - limbInteraction.limbMover.limbPivot.position;
            handDir.Normalize();
            Quaternion lookRot = Quaternion.LookRotation(handDir, Vector3.up);
            transform.eulerAngles = lookRot.eulerAngles + new Vector3(-90, 0, 0);
        }
    }

    public override void Pickup()
    {

    }

    public override void Drop()
    {

    }
}