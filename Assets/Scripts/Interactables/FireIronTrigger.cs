using UnityEngine;

public class FireIronTrigger : MonoBehaviour
{
    [SerializeField] private Transform cheeseTransform;
    [SerializeField] private Rat rat;

    private bool hasCheese;

    private void Update()
    {
        if (hasCheese)
        {
            cheeseTransform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == cheeseTransform)
        {
            hasCheese = true;
        }
        if (hasCheese && other.transform == rat.transform)
        {
            Destroy(cheeseTransform.gameObject);
            hasCheese = false;
            rat.ReceiveCheese();
        }
    }
}
