using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TimerChain timerChain;
    [SerializeField] private float textFadeTime = 1f;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform headTransform;
    [Tooltip("Total movement of the head in degrees that counts as a yes.")]
    [SerializeField] private float movementToAnswerYes = 150f;
    [Tooltip("Total movement of the head in degrees that counts as a no.")]
    [SerializeField] private float movementToAnswerNo = 400f;
    [SerializeField] private List<Question> questions;

    private Question currentQuestion => questions[currentQuestionIndex];
    private int currentQuestionIndex = -1;
    private Quaternion lastHeadRot;
    private Vector2 headMoveAmount;
    private bool isWaitingForAnswer;

    private void Start()
    {
        NextQuestion();
    }

    private void Update()
    {
        if (isWaitingForAnswer)
        {
            WaitForAnswer();
        }
    }

    private void NextQuestion()
    {
        headMoveAmount = Vector2.zero;
        lastHeadRot = headTransform.rotation;
        currentQuestionIndex++;
        isWaitingForAnswer = true;
        subtitleText.text = currentQuestion.question;
        canvasGroup.FadeIn(textFadeTime);
        StartQuestionCountdown(currentQuestionIndex);
    }

    private async void StartQuestionCountdown(int questionIndex)
    {
        await Awaitable.WaitForSecondsAsync(currentQuestion.displayDuration);

        if (questionIndex == currentQuestionIndex && canvasGroup.alpha > 0f)
        {
            canvasGroup.FadeOut(textFadeTime);
        }
    }

    private void WaitForAnswer()
    {
        Quaternion currentHeadRot = headTransform.rotation;

        float diffX = Vector3.SignedAngle(currentHeadRot * Vector3.up, lastHeadRot * Vector3.up, Vector3.right);
        float diffY = Vector3.SignedAngle(currentHeadRot * Vector3.forward, lastHeadRot * Vector3.forward, Vector3.up);

        headMoveAmount += new Vector2(Mathf.Abs(diffX), Mathf.Abs(diffY));

        if (headMoveAmount.x > movementToAnswerYes)
        {
            Answer(true);
        }
        else if (headMoveAmount.y > movementToAnswerNo)
        {
            Answer(false);
        }

        lastHeadRot = currentHeadRot;
    }

    private async void Answer(bool answer)
    {
        canvasGroup.FadeOut(textFadeTime);
        isWaitingForAnswer = false;

        if (answer == currentQuestion.correctAnswer)
        {
            timerChain.timeElapsed -= currentQuestion.timeAddedWhenCorrect;
        }
        else
        {
            timerChain.timeElapsed += currentQuestion.timeRemovedWhenWrong;
        }

        await Awaitable.WaitForSecondsAsync(currentQuestion.waitDurationAfterQuestion);

        if (currentQuestionIndex < questions.Count - 1)
            NextQuestion();
    }
}