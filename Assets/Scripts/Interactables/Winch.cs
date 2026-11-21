using UnityEngine;

public class Winch : MonoBehaviour
{
    [SerializeField] private MainChain mainChain;

    public void AddChain(float amount)
    {
        mainChain.totalMaxLength += amount;
    }
}