using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    [SerializeField] private int hitsRequired = 3;
    [SerializeField] private SpringJoint joint;

    private int hits;

    private void OnCollisionEnter(Collision other)
    {
        hits++;

        if (joint && hits > hitsRequired - 1)
        {
            Destroy(joint);
        }
    }
}