using UnityEngine;

public class Player : MonoBehaviour
{
    public static LimbSelection limbSelection;

    private void Start()
    {
        limbSelection = GetComponent<LimbSelection>();
    }
}