using UnityEngine;

public class LockedCompartment : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;

    private void Start()
    {
        objectToEnable.SetActive(false);
    }

    public void Unlock()
    {
        objectToEnable.SetActive(true);
    }
}