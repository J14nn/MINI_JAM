using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class Chain : MonoBehaviour
{
    public Transform chainStartTranform;
    public float length = 6f;

    [SerializeField] private Transform connectedTransform;

    private SplineContainer splineContainer;

    private void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    private void Update()
    {
        UpdateChain();
    }

    private void UpdateChain()
    {
        Spline spline = splineContainer.Splines[0];

        BezierKnot firstKnot = spline[0];
        Vector3 localPos = splineContainer.transform.InverseTransformPoint(connectedTransform.position);
        firstKnot.Position = localPos;

        spline.SetKnot(0, firstKnot);
    }
}