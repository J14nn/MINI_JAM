using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource chainMovingSource;
    [SerializeField] private AudioClip[] chainMovingClips;
    [SerializeField] private float chainMovingSourceVolume = 0.2f;

    private bool isStopping;

    public void PlayChainMoving()
    {
        if (chainMovingSource.isPlaying || isStopping)
            return;

        chainMovingSource.DOKill();
        chainMovingSource.volume = chainMovingSourceVolume;
        chainMovingSource.clip = chainMovingClips.Random();
        chainMovingSource.Play();
    }

    public void StopChainMoving()
    {
        if (!chainMovingSource.isPlaying || isStopping)
            return;

        isStopping = true;
        chainMovingSource.DOFade(0f, 0.5f).OnComplete(() =>
        {
            chainMovingSource.Stop();
            chainMovingSource.volume = chainMovingSourceVolume;
            isStopping = false;
        });
    }
}