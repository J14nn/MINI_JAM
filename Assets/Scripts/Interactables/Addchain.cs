using UnityEngine;

public class Addchain : PickableItem
{
    public float lengthIncrease = 1.5f;
    public bool isPickable = false;

    [SerializeField] private GameObject chainObject;

    private bool wasAdded = false;
    private float lastHitTime = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isPickable) return;
        MoveChainToHand();
    }

    private void MoveChainToHand()
    {
        if (!limbInteraction) return;

        transform.position = limbInteraction.itemPosition.position;
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

    private void OnCollisionEnter(Collision other)
    {
        if (Time.time - lastHitTime > 1.2f && rb.linearVelocity.magnitude > 0.3f)
        {
            lastHitTime = Time.time;
            Globals.soundManager.PlaySound(Globals.soundManager.chainHitClip);
        }
    }
}