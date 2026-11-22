using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [HideInInspector] public LimbInteraction limbInteraction;

    public virtual void Pickup()
    {

    }

    public virtual void Drop()
    {

    }
}