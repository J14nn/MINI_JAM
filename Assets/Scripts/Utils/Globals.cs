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
    public static bool hasWon;
    public static PlayerRagdoll playerRagdoll;
    public static PlayerDeath playerDeath;

    private void Awake()
    {
        isGameOver = false;
        hasWon = false;
        playerDeath = GetComponent<PlayerDeath>();
        playerRagdoll = GetComponent<PlayerRagdoll>();
        soundManager = FindAnyObjectByType<SoundManager>();
        limbSelection = GetComponent<LimbSelection>();
        playerLayer = _playerLayer;
        cursorDefault = _cursorDefault;
        cursorInteraction = _cursorInteraction;
    }

    private void Start()
    {

    }
}