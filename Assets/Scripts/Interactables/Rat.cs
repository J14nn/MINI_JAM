using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [HideInInspector] public bool canBeStabbed;

    [SerializeField] private LowerChain chainToLower;
    [SerializeField] private Vector3 finalMovePos;
    [SerializeField] private float moveSpeed = 1f;

    public void ReceiveCheese()
    {
        chainToLower.Lower();
    }

    public async void MoveToPlayer()
    {
        await transform.DOMove(finalMovePos, moveSpeed).SetSpeedBased().AsyncWaitForCompletion();

        canBeStabbed = true;
    }
}