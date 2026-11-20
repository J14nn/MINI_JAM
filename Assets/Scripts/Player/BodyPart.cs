using UnityEngine;

public abstract class BodyPart : MonoBehaviour
{
    [HideInInspector] public LimbInteraction limbInteraction;

    public Chain chain;

    public abstract void Move();
}