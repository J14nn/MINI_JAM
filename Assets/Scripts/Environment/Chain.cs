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

    private void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    private void Update()
    {
        UpdateChain();
    }

    public void TryToShortenChain(float amount)
    {
        LimbMover limb = connectedPart as LimbMover;
        Vector3 dirToChain = (chainStartTranform.position - connectedTransform.position).normalized;
        limb.limbTarget.transform.position += dirToChain * amount;
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