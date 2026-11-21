using UnityEngine;

public class Addchain : PickableItem
{
    public float lengthIncrease = 1.5f;

    [SerializeField] private GameObject chainObject;
    [SerializeField] private GameObject handObject;

    public override void Pickup()
    {
        chainObject.SetActive(false);
        handObject.SetActive(true);
    }

    public override void Drop()
    {
        chainObject.SetActive(false);
        handObject.SetActive(true);
    }
}