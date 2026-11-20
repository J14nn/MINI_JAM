using UnityEngine;

public abstract class BodyPart : MonoBehaviour
{
    [HideInInspector] public LimbInteraction limbInteraction;

    public abstract void Move();
}