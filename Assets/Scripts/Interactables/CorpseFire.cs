using System.Threading.Tasks;
using UnityEngine;

public class CorpseFire : MonoBehaviour
{
    [Tooltip("How long it takes the rat to notice fire and move.")]
    [SerializeField] private float ratNoticeFireTime = 4f;
    [SerializeField] private Rat rat;

    public async void StartFire()
    {
        await Awaitable.WaitForSecondsAsync(ratNoticeFireTime);

        rat.MoveToPlayer();
    }
}