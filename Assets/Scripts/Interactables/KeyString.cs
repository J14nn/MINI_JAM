using DG.Tweening;
using UnityEngine;

public class KeyString : MonoBehaviour
{
    [SerializeField] private Lever lever;
    [Tooltip("How much the key moves down when level is pressed.")]
    [SerializeField] private float lowerAmount = 2f;
    [SerializeField] private float lowerSpeed = 1f;
    [SerializeField] private float raiseSpeed = 1f;

    private float startPosY;

    private void Start()
    {
        startPosY = transform.position.y;
    }

    private void Update()
    {
        if (lever.isActivated)
            LowerKey();
        else
            RaiseKey();
    }

    private void LowerKey()
    {
        transform.DOKill();
        transform.DOMoveY(startPosY - lowerAmount, lowerSpeed).SetSpeedBased().SetEase(Ease.Linear);
    }

    private void RaiseKey()
    {
        transform.DOKill();
        transform.DOMoveY(startPosY + lowerAmount, raiseSpeed).SetSpeedBased().SetEase(Ease.Linear);
    }
}