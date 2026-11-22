using UnityEngine;

public class Addchain : MonoBehaviour
{
    public float lengthIncrease = 1.5f;

    [SerializeField] private GameObject chainObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Winch winch))
        {
            winch.AddChain(lengthIncrease);
            Destroy(gameObject, 0.1f);
        }
    }
}