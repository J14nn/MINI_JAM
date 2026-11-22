using UnityEngine;

public class TimerChain : MonoBehaviour
{
    [Tooltip("The maximum time required to complete the level.")]
    [SerializeField] private float maxTime = 250f;
    [Tooltip("How far the player's head will move - when it reaches this amount, player will be dead.")]
    [SerializeField] private float headPositionChangeY = 1f;
    [SerializeField] private Transform playerHeadTransform;
    [SerializeField] private float gruntCrackCooldown = 30f;
    [Tooltip("By how much the next grunt/crack time decreases. (eg first after 100s, multiplier 0.9 so next after 90s).")]
    [SerializeField] private float nextGruntCrackTimeMultiplier = 0.9f;

    private float nextGruntCrackTime;
    private Vector3 initialHeadPos;
    private Vector3 initialTransformPos;
    public float timeElapsed = 0.000001f;

    private void Start()
    {
        nextGruntCrackTime = gruntCrackCooldown;
        initialHeadPos = playerHeadTransform.position;
        initialTransformPos = transform.position;
    }

    private void Update()
    {
        if (timeElapsed > nextGruntCrackTime)
        {
            Globals.soundManager.PlayGruntCrack();
            gruntCrackCooldown *= nextGruntCrackTimeMultiplier;
            nextGruntCrackTime += gruntCrackCooldown;
        }

        if (timeElapsed > maxTime && !Globals.isGameOver)
        {
            Globals.isGameOver = true;
            Globals.soundManager.PlayHeadRip();
            Time.timeScale = 0f;
        }
    }

    public void AdvanceTime()
    {
        timeElapsed += Time.deltaTime;
        playerHeadTransform.position = initialHeadPos + Vector3.up * headPositionChangeY * timeElapsed / maxTime;
        transform.position = initialTransformPos + Vector3.up * headPositionChangeY * timeElapsed / maxTime;
    }
}