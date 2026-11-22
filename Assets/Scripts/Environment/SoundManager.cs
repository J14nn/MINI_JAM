using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip pickUpItemClip, eatChainClip, ratWalkClip, ratStabClip, ratDieClip,
    cheesePickupClip, compartmentOpenClip, leverActiveClip, leverInactiveClip, chainHitClip;
    [SerializeField] private AudioSource chainMovingSource;
    [SerializeField] private AudioClip[] chainMovingClips;
    [SerializeField] private float chainMovingSourceVolume = 0.2f;
    [SerializeField] private AudioSource headRipSource;
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioSource gruntAndCrackSource;
    [SerializeField] private AudioClip[] gruntAndCrackClips;
    [SerializeField] private AudioClip[] ratRabiesClips;
    [SerializeField] private AudioClip[] ratRonnieClips;
    [SerializeField] private AudioSource ratSource;
    [SerializeField] private AudioSource chainSnapSource;
    [SerializeField] private AudioSource singleSoundSource;
    [SerializeField] private AudioSource fireSource;
    [SerializeField] private AudioSource machineBreakdownSource;

    private bool chainMovingIsStopping;
    private float lastChainSnapTime = 0;
    private float defaultSoundVolume;

    private void Start()
    {
        defaultSoundVolume = singleSoundSource.volume;
    }

    public void PlayChainMoving()
    {
        if (chainMovingSource.isPlaying || chainMovingIsStopping)
            return;

        chainMovingSource.DOKill();
        chainMovingSource.volume = chainMovingSourceVolume;
        chainMovingSource.clip = chainMovingClips.Random();
        chainMovingSource.Play();
    }

    public void StopChainMoving()
    {
        if (!chainMovingSource.isPlaying || chainMovingIsStopping)
            return;

        chainMovingIsStopping = true;
        chainMovingSource.DOFade(0f, 0.5f).OnComplete(() =>
        {
            chainMovingSource.Stop();
            chainMovingSource.volume = chainMovingSourceVolume;
            chainMovingIsStopping = false;
        });
    }

    public void PlayHeadRip()
    {
        headRipSource.Play();
        chainMovingSource.mute = true;
        backgroundSource.mute = true;
        fireSource.mute = true;
    }

    public void PlayGruntCrack()
    {
        gruntAndCrackSource.clip = gruntAndCrackClips.Random();
        gruntAndCrackSource.Play();
    }

    public void PlayRatSound(RatName rat)
    {
        AudioClip clip;

        if (rat == RatName.Rabies)
        {
            clip = ratRabiesClips.Random();
        }
        else
        {
            clip = ratRonnieClips.Random();
        }

        ratSource.clip = clip;
        ratSource.Play();
    }

    public void PlayChainSnap()
    {
        if (Time.time - lastChainSnapTime > 3f)
        {
            lastChainSnapTime = Time.time;
            chainSnapSource.Play();
        }
    }

    public void PlaySound(AudioClip clip, float volume = -1)
    {
        if (volume > 0)
        {
            singleSoundSource.volume = volume;
        }
        else
        {
            singleSoundSource.volume = defaultSoundVolume;
        }
        singleSoundSource.clip = clip;
        singleSoundSource.Play();
    }

    public void PlayFireSound()
    {
        fireSource.Play();
    }

    public void PlayMachineBreakdown()
    {
        machineBreakdownSource.Play();
    }
}