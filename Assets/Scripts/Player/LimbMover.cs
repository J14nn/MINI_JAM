using System;
using UnityEngine;

public class LimbMover : MonoBehaviour
{
    [HideInInspector] public LimbInteraction limbInteraction;

    [SerializeField] private Transform limbTarget;
    [SerializeField] private Transform limbPivot;
    [SerializeField] private LayerMask defaultLayer;
    [SerializeField] private float handMinReach = 1f;

    private void Start()
    {
        limbInteraction = GetComponent<LimbInteraction>();
    }

    public void MoveLimb()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, defaultLayer))
        {
            SetLimbTargetPos(hit.point);
            float angle = GetAngleBetweenTwoPositions(limbPivot.position, hit.point);
            limbTarget.eulerAngles = new Vector3(angle + 90f, -90f, 0);
        }
    }

    private void SetLimbTargetPos(Vector3 hitPoint)
    {
        float distLimbPivotToHitPoint = Vector3.Distance(limbPivot.position, hitPoint);

        if (distLimbPivotToHitPoint < handMinReach)
        {
            Vector3 dirLimbPivotToHitPoint = (hitPoint - limbPivot.position).normalized;
            limbTarget.position = limbPivot.position + dirLimbPivotToHitPoint * handMinReach;
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