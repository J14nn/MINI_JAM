using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Texture2D _cursorDefault;
    [SerializeField] private Texture2D _cursorInteraction;

    public static LimbSelection limbSelection;
    public static LayerMask playerLayer;
    public static Texture2D cursorDefault;
    public static Texture2D cursorInteraction;
    public static SoundManager soundManager;
    public static bool isGameOver;

    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        limbSelection = GetComponent<LimbSelection>();
        playerLayer = _playerLayer;
        cursorDefault = _cursorDefault;
        cursorInteraction = _cursorInteraction;
    }
}