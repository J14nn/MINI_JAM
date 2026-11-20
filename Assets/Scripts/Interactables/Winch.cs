using UnityEngine;

public class Winch : MonoBehaviour
{
    [SerializeField] private MainChain mainChain;
    [SerializeField] private float lengthIncreasePerChain = 3f;

    public void AddChain()
    {
        mainChain.totalMaxLength += lengthIncreasePerChain;
    }
}