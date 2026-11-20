using UnityEngine;

public class Addchain : PickableItem
{
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