using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [HideInInspector] public LimbInteraction limbInteraction;
    public bool canBePickedByMouth = true;
    public bool canBePickedUp = true;

    public virtual void Pickup()
    {

    }

    public virtual void Drop()
    {

    }
}