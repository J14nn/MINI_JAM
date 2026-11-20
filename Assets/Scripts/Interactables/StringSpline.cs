using UnityEngine;
using UnityEngine.Splines;

public class StringSpline : MonoBehaviour
{
    [SerializeField] private Transform attachPoint;

    private SplineContainer splineContainer;

    private void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    private void Update()
    {
        Spline spline = splineContainer.Splines[0];

        BezierKnot firstKnot = spline[0];
        Vector3 localPos = splineContainer.transform.InverseTransformPoint(attachPoint.position);
        firstKnot.Position = localPos;

        spline.SetKnot(0, firstKnot);
    }
}