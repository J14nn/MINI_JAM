using UnityEngine;

public class Addchain : MonoBehaviour
{
    public float lengthIncrease = 1.5f;

    [SerializeField] private GameObject chainObject;

    private bool wasAdded = false;
    private float lastHitTime = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Winch winch) && !wasAdded)
        {
            wasAdded = true;
            winch.AddChain(lengthIncrease);
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (Time.time - lastHitTime > 1.2f && rb.linearVelocity.magnitude > 0.1f)
        {
            lastHitTime = Time.time;
            Globals.soundManager.PlaySound(Globals.soundManager.chainHitClip);
        }
    }
}