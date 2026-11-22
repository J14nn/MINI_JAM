using UnityEngine;

public class Winch : MonoBehaviour
{
    [SerializeField] private MainChain mainChain;

    public async void AddChain(float amount)
    {
        Globals.soundManager.PlaySound(Globals.soundManager.eatChainClip);
        await Awaitable.WaitForSecondsAsync(1.8f);
        mainChain.totalMaxLength += amount;
    }
}