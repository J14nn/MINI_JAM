using UnityEngine;

public class Footinteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private LayerMask interactableLayer;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactionRange, interactableLayer);

        if (hits != null && hits.Length > 0)
        {
            Lever lever = hits[0].transform.GetComponentInParent<Lever>();
            if (lever)
            {
                lever.PushDown();
            }
        }
    }
}
