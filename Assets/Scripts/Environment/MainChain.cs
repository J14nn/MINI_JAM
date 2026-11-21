
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainChain : MonoBehaviour
{
    public float totalMaxLength = 20f;

    [SerializeField] private TimerChain timerChain;
    [SerializeField] private List<Chain> chains;
    [SerializeField] private LimbSelection limbSelection;
    [Tooltip("Multiplier for speed at which time chain moves when player stretches limbs too far. (1 is normal speed)")]
    [SerializeField] private float timeChainSpeedMultiplier = 2f;

    public float usedLength;

    public void UpdateChainsAndLimbs()
    {
        UpdateUsedLength();

        if (usedLength > totalMaxLength)
        {
            timerChain.timeElapsed += Time.deltaTime * (timeChainSpeedMultiplier - 1f);

            List<Chain> longestChains = chains.OrderByDescending(chain => chain.usedLength).ToList();
            float shortenAmount = usedLength - totalMaxLength;

            foreach (Chain chain in longestChains)
            {
                if (chain != limbSelection.selectedPart.chain)
                {
                    chain.TryToShortenChain(shortenAmount);
                }
            }

            UpdateUsedLength();

            if (usedLength > totalMaxLength &&
                limbSelection.selectedPart != null &&
                limbSelection.selectedPart.chain != null)
            {
                limbSelection.selectedPart.chain.TryToShortenChain(usedLength - totalMaxLength);
            }
        }

        UpdateUsedLength();

        float remainingLength = Mathf.Max(0f, totalMaxLength - usedLength);
        float looseness = remainingLength / chains.Count;

        foreach (Chain chain in chains)
        {
            chain.UpdateChain(looseness);
        }
    }

    private void UpdateUsedLength()
    {
        float length = 0f;

        foreach (Chain chain in chains)
        {
            length += chain.usedLength;
        }

        usedLength = length;
    }
}