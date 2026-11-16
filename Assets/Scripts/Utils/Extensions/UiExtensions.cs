using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public static class UiExtensions
{
    public static void SetAlpha(this Image image, float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public static void FadeIn(this CanvasGroup canvas, float duration)
    {
        canvas.DOFade(1, duration);
        canvas.blocksRaycasts = true;
        canvas.interactable = true;
    }

    public static void FadeOut(this CanvasGroup canvas, float duration)
    {
        canvas.blocksRaycasts = false;
        canvas.interactable = false;
        canvas.DOFade(0, duration);
    }

    public static async Task FadeOutAsync(this CanvasGroup canvas, float duration)
    {
        canvas.blocksRaycasts = false;
        canvas.interactable = false;
        await canvas.DOFade(0, duration).AsyncWaitForCompletion();
    }
}