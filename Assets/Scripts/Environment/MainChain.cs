using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainChain : MonoBehaviour
{
    public float totalMaxLength = 20f;

    [SerializeField] private List<Chain> chains;
    [SerializeField] private LimbSelection limbSelection;

    public float usedLength;

    public void UpdateChainsAndLimbs()
    {
        UpdateUsedLength();

        if (usedLength <= totalMaxLength) return;

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
        if (usedLength > totalMaxLength)
        {
            limbSelection.selectedPart.chain.TryToShortenChain(usedLength - totalMaxLength);
        }

        /*float distChainToHitPoint = Vector3.Distance(chain.chainStartTranform.position, hitPoint);

        if (distChainToHitPoint > chain.length)
        {
            Vector3 dirChainToHitPoint = (hitPoint - chain.chainStartTranform.position).normalized;
            limbTarget.position = chain.chainStartTranform.position + dirChainToHitPoint * chain.length;
        }
*/
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