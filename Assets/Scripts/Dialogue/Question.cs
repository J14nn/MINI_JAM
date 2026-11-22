using UnityEngine;

[System.Serializable]
public class Question
{
    public RatName talkingRat;
    public string question;
    [Tooltip("The answer the rat wants you to hear (yes or no).")]
    public bool correctAnswer;
    public bool isQuestion = true;
    [Tooltip("What the rat answers when player chooses the correct answer.")]
    public string answerWhenCorrect;
    [Tooltip("What the rat answers when the player chooses wrong answer")]
    public string answerWhenWrong;
    [Tooltip("Time that will be added to the chain when you answer correctly.")]
    public float timeAddedWhenCorrect = 20f;
    [Tooltip("Time that will be subtracted from the chain when you answer wrongly.")]
    public float timeRemovedWhenWrong = 10f;
    public float questionDisplayDuration = 20f;
    public float answerDisplayDuration = 7f;
    public float waitDurationAfterQuestion = 20f;
}

public enum RatName { Rabies, Ronnie }