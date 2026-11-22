using UnityEngine;

public class RagdollComponent : MonoBehaviour
{
    private Collider col;
    private CharacterJoint joint;
    private Rigidbody rb;

    private void Awake()
    {
        col = GetComponent<Collider>();
        joint = GetComponent<CharacterJoint>();
        rb = GetComponent<Rigidbody>();
    }

    public void DisableRagdoll()
    {
        col.enabled = false;
        rb.isKinematic = true;
    }

    public void EnableRagdoll()
    {
        col.enabled = true;
        rb.isKinematic = false;
    }
}