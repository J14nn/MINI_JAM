using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class Chain : MonoBehaviour
{
    public Transform chainStartTranform;
    public float usedLength
    {
        get
        {
            return Vector3.Distance(chainStartTranform.position, connectedTransform.position);
        }
    }

    [SerializeField] private Transform connectedTransform;
    [SerializeField] private BodyPart connectedPart;

    private SplineContainer splineContainer;

    private void Awake()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    public void TryToShortenChain(float amount)
    {
        LimbMover limb = connectedPart as LimbMover;
        Vector3 dirToChain = (chainStartTranform.position - connectedTransform.position).normalized;
        limb.limbTarget.transform.position += dirToChain * amount;
    }



    public void UpdateChain(float looseness)
    {
        Spline spline = splineContainer.Splines[0];

        Vector3 start = connectedTransform.position;
        Vector3 end = chainStartTranform.position;

        Vector3 middle = (start + end) / 2f;
        middle += Vector3.down * looseness;

        Vector3[] positions = { start, middle, end };

        for (int i = 0; i < positions.Length; i++)
        {
            BezierKnot knot = spline[i];
            knot.Position = splineContainer.transform.InverseTransformPoint(positions[i]);
            spline.SetKnot(i, knot);
        }
    }

}