using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private ParticleSystem bloodParticles;
    [SerializeField] private Transform neckBone;

    private void Update()
    {
        /*if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameOver();
            Globals.isGameOver = true;
        }*/
    }

    public void GameOver()
    {
        head.SetActive(true);
        neckBone.localEulerAngles = new Vector3(0f, 0f, 165f);
        bloodParticles.Play();
    }
}