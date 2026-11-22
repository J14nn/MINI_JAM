using UnityEngine;

public class FireIronTrigger : MonoBehaviour
{
    [SerializeField] private Transform cheeseTransform;
    [SerializeField] private Rat rat;
    [SerializeField] private Transform chainContraption;

    private Transform selectedTransform;

    private void Update()
    {
        if (selectedTransform)
        {
            selectedTransform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == cheeseTransform)
        {
            Globals.soundManager.PlaySound(Globals.soundManager.cheesePickupClip);
            selectedTransform = cheeseTransform;
        }

        if (cheeseTransform && selectedTransform == cheeseTransform && other.transform == rat.transform)
        {
            Destroy(cheeseTransform.gameObject);
            cheeseTransform = null;
            selectedTransform = null;
            rat.ReceiveCheese();
        }

        if (other.transform == rat.transform && rat.canBeStabbed)
        {
            Globals.soundManager.PlaySound(Globals.soundManager.ratStabClip);
            selectedTransform = rat.transform;
        }

        if (other.transform == chainContraption && selectedTransform && selectedTransform == rat.transform)
        {
            Globals.soundManager.PlaySound(Globals.soundManager.ratDieClip);
            Globals.soundManager.PlayMachineBreakdown();
            Debug.Log("You won");
        }
    }
}
