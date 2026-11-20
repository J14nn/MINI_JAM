using System;
using UnityEngine;

public class LimbMover : BodyPart
{
    [SerializeField] private Transform limbTarget;
    [SerializeField] private Transform limbPivot;
    [SerializeField] private LayerMask defaultLayer;
    [SerializeField] private float minReach = 1f;
    [SerializeField] private Chain chain;
    [SerializeField] private float minRotationAngle = 0f;
    [SerializeField] private float maxRotationAngle = 360f;

    private float limbStartPosZ;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, defaultLayer))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.z = limbStartPosZ;

            SetTargetPosition(hitPoint);
            SetTargetRotation();
        }
    }

    private void SetTargetRotation()
    {
        float angle = GetAngleBetweenTwoPositions(limbPivot.position, limbTarget.position);
        limbTarget.eulerAngles = new Vector3(angle + 90f, -90f, 0);
    }

    private void SetTargetPosition(Vector3 hitPoint)
    {
        float limbAngle = GetAngleBetweenTwoPositions(limbPivot.position, limbTarget.position);
        //Debug.Log(limbAngle);

        float distChainToHitPoint = Vector3.Distance(chain.chainStartTranform.position, hitPoint);

        if (distChainToHitPoint > chain.length)
        {
            Vector3 dirChainToHitPoint = (hitPoint - chain.chainStartTranform.position).normalized;
            limbTarget.position = chain.chainStartTranform.position + dirChainToHitPoint * chain.length;
        }
        else
        {
            float distLimbPivotToHitPoint = Vector3.Distance(limbPivot.position, hitPoint);

            if (distLimbPivotToHitPoint < minReach)
            {
                Vector3 dirLimbPivotToHitPoint = (hitPoint - limbPivot.position).normalized;
                limbTarget.position = limbPivot.position + dirLimbPivotToHitPoint * minReach;
            }
            else
            {
                limbTarget.position = hitPoint;
            }
        }
    }

    private float GetAngleBetweenTwoPositions(Vector3 posA, Vector3 posB)
    {
        float dx = posB.x - posA.x;
        float dy = posB.y - posA.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }
}