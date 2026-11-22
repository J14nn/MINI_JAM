using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CorpseFire : MonoBehaviour
{
    [SerializeField] private float fireSpreadTime = 4f;
    [SerializeField] private Rat rat;
    [SerializeField] private List<GameObject> particleSystems;

    public async void StartFire()
    {
        float timePerFire = fireSpreadTime / particleSystems.Count;

        foreach (GameObject obj in particleSystems)
        {
            obj.SetActive(true);
            await Awaitable.WaitForSecondsAsync(timePerFire);
        }

        rat.MoveToPlayer();
    }
}