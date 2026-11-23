using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private ParticleSystem bloodParticles;
    [SerializeField] private Transform neckBone;
    [SerializeField] private CanvasGroup deathUI;

    private void Start()
    {
        deathUI.alpha = 0f;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GameOver();
            Globals.isGameOver = true;
        }
    }

    public async void GameOver()
    {
        head.SetActive(true);
        Globals.soundManager.PlayHeadRip();
        neckBone.localEulerAngles = new Vector3(0f, 0f, 165f);
        bloodParticles.Play();
        await Awaitable.WaitForSecondsAsync(2f);
        deathUI.FadeIn(1f);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}