using UnityEngine;

public class Addchain : MonoBehaviour
{
    public float lengthIncrease = 1.5f;

    [SerializeField] private GameObject chainObject;

    private bool wasAdded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Winch winch) && !wasAdded)
        {
            wasAdded = true;
            winch.AddChain(lengthIncrease);
            Destroy(gameObject, 0.1f);
        }
    }
}