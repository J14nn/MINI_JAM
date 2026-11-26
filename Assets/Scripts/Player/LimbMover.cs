using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LimbMover : BodyPart
{
    public Transform limbTarget;
    public Transform limbPivot;

    [SerializeField] private TimerChain timerChain;
    [SerializeField] private LayerMask defaultLayer;
    [SerializeField] private float minReach = 1f;
    [SerializeField] private float maxReach = 5f;
    [SerializeField] private float acceleration = 120f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float friction = 30f;

    private float limbStartPosZ;
    private Vector3 velocity;

    private void Start()
    {
        limbStartPosZ = limbPivot.transform.position.z;
        Vector3 limbTargetPos = limbTarget.position;
        limbTargetPos.z = limbStartPosZ;
        limbTarget.position = limbTargetPos;

        limbInteraction = GetComponent<LimbInteraction>();
        SetTargetRotation();
    }

    public override void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, defaultLayer))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.z = limbStartPosZ;

            Vector3 direction = hitPoint - limbTarget.position;

            if (direction.magnitude > 0.05f)
            {
                velocity += direction.normalized * acceleration * Time.deltaTime;
                timerChain.AdvanceTime();
                Globals.soundManager.PlayChainMoving();
            }

            velocity *= Mathf.Exp(-friction * Time.deltaTime);

            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }

            SetTargetPosition(limbTarget.position + velocity * Time.deltaTime);
            SetTargetRotation();
        }
    }

    private void SetTargetRotation()
    {
        float angle = GetAngleBetweenTwoPositions(limbPivot.position, limbTarget.position);
        limbTarget.eulerAngles = new Vector3(angle, 0, 0);
    }

    private void SetTargetPosition(Vector3 hitPoint)
    {
        float distLimbPivotToHitPoint = Vector3.Distance(limbPivot.position, hitPoint);

        if (distLimbPivotToHitPoint < minReach)
        {
            Vector3 dirLimbPivotToHitPoint = (hitPoint - limbPivot.position).normalized;
            limbTarget.position = limbPivot.position + dirLimbPivotToHitPoint * minReach;
        }
        else if (distLimbPivotToHitPoint > maxReach)
        {
            Vector3 dirLimbPivotToHitPoint = (hitPoint - limbPivot.position).normalized;
            limbTarget.position = limbPivot.position + dirLimbPivotToHitPoint * maxReach;
        }
        else
        {
            limbTarget.position = hitPoint;
        }
    }

    private float GetAngleBetweenTwoPositions(Vector3 posA, Vector3 posB)
    {
        float dx = posB.x - posA.x;
        float dy = posB.y - posA.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }
}