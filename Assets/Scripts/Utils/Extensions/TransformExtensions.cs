using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public static class TransformExtensions
{
    public static void LookAt2D(this Transform transform, Vector2 target, bool ninetyDegreeOffset = false)
    {
        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (ninetyDegreeOffset) angle -= 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public static void LookAt2dSmooth(this Transform transform, Vector2 target, float smoothness, float maxRotationSpeed, bool ninetyDegreeOffset = false)
    {
        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (ninetyDegreeOffset) angle -= 90f;

        float currentAngle = transform.eulerAngles.z;

        float step = maxRotationSpeed * Time.deltaTime;

        float desiredAngle = Mathf.LerpAngle(currentAngle, angle, smoothness * Time.deltaTime);

        float finalAngle = Mathf.MoveTowardsAngle(currentAngle, desiredAngle, step);

        transform.rotation = Quaternion.Euler(0, 0, finalAngle);
    }

    public static async void FollowTransform(this Transform follower, Transform destination, float speed, Action onCompleted, bool destroyOnCompleted)
    {
        while (Vector2.Distance(follower.position, destination.position) > 0.3f)
        {
            follower.DOKill();
            follower.DOMove(destination.position, speed).SetSpeedBased();
            await Task.Delay(50);
        }

        onCompleted?.Invoke();

        if (destroyOnCompleted)
        {
            GameObject.Destroy(follower.gameObject);
        }
    }
}