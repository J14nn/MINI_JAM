using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] private LowerChain chainToLower;

    public void ReceiveCheese()
    {
        chainToLower.Lower();
    }
}