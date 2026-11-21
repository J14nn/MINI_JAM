using UnityEngine;

[System.Serializable]
public class Question
{
    public string question;
    [Tooltip("The answer the rat wants you to hear (yes or no).")]
    public bool correctAnswer;
    [Tooltip("Time that will be added to the chain when you answer correctly.")]
    public float timeAddedWhenCorrect = 20f;
    [Tooltip("Time that will be subtracted from the chain when you answer wrongly.")]
    public float timeRemovedWhenWrong = 10f;
    public float displayDuration = 20f;
    public float waitDurationAfterQuestion = 20f;
}