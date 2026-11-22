using DG.Tweening;
using UnityEngine;

public class LowerChain : MonoBehaviour
{
    [Tooltip("How much the key moves down when level is pressed.")]
    [SerializeField] private float lowerAmount = 2f;
    [SerializeField] private float lowerSpeed = 1f;

    private float startPosY;

    private void Start()
    {
        startPosY = transform.position.y;
    }

    public void Lower()
    {
        transform.DOMoveY(startPosY - lowerAmount, lowerSpeed).SetSpeedBased().SetEase(Ease.Linear);
    }
}
