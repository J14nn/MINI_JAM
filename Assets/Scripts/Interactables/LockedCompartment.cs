using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class LockedCompartment : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private Transform doorPivot;

    private void Start()
    {
        objectToEnable.SetActive(false);
    }

    public async void Unlock()
    {
        Globals.soundManager.PlaySound(Globals.soundManager.compartmentOpenClip);
        doorPivot.DOLocalRotate(new Vector3(0f, -157.477f, 0f), 1f);
        await Awaitable.WaitForSecondsAsync(1f);
        objectToEnable.SetActive(true);
    }
}