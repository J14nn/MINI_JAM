using UnityEngine;

public class TimerChain : MonoBehaviour
{
    [Tooltip("The maximum time required to complete the level.")]
    [SerializeField] float maxTime = 250f;
    [Tooltip("How far the player's head will move - when it reaches this amount, player will be dead.")]
    [SerializeField] float headPositionChangeY = 1f;
    [SerializeField] Transform playerHeadTransform;

    private Vector3 initialHeadPos;
    public float timeElapsed = 0.000001f;

    private void Start()
    {
        initialHeadPos = playerHeadTransform.position;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        playerHeadTransform.position = initialHeadPos + Vector3.up * headPositionChangeY * timeElapsed / maxTime;

        if (timeElapsed > maxTime)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}