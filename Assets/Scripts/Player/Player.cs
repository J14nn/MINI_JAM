using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    public static LimbSelection limbSelection;
    public static LayerMask playerLayer;

    private void Start()
    {
        limbSelection = GetComponent<LimbSelection>();
        playerLayer = _playerLayer;
    }
}