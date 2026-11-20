using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Transform leverPivot;
    [SerializeField] private Chain chainToExtend;
    [SerializeField] private float extendAmount = 3f;

    private HingeJoint joint;
    private Rigidbody rb;
    private bool isActivated;

    private void Start()
    {
        joint = GetComponentInChildren<HingeJoint>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        CheckForActivation();
    }

    private void CheckForActivation()
    {
        if (isActivated) return;

        if (leverPivot.localEulerAngles.x < 315f && leverPivot.localEulerAngles.x > 300f)
        {
            isActivated = true;
            chainToExtend.length += extendAmount;
            Destroy(joint);
            Destroy(rb);
        }
    }
}