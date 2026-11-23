using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [HideInInspector] public bool canBeStabbed;

    [SerializeField] private LowerChain chainToLower;
    [SerializeField] private List<Vector3> movePos;
    [SerializeField] private float moveSpeed = 1f;

    public void ReceiveCheese()
    {
        chainToLower.Lower();
    }

    public async void MoveToPlayer()
    {
        foreach (Vector3 pos in movePos)
        {
            Globals.soundManager.PlaySound(Globals.soundManager.ratWalkClip);
            await transform.DOMove(pos, moveSpeed).SetSpeedBased().AsyncWaitForCompletion();
        }

        canBeStabbed = true;
    }
}