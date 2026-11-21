using UnityEngine;

public class RbDontSleep : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0f;
    }
}