using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Transform leverPivot;
    [SerializeField] private float releaseSpeed = 20f;
    [SerializeField] private float pushDownSpeed = 20f;
    [SerializeField] private float minAngle = 40f;
    [SerializeField] private float maxAngle = 130f;
    [SerializeField] private float activationAngle = 45;

    public bool isActivated;
    private float _currentAngle;

    private void Start()
    {
        float startX = leverPivot.localEulerAngles.x;
        if (startX > 180f) startX -= 360f;
        _currentAngle = Mathf.Clamp(startX, minAngle, maxAngle);
    }

    private void Update()
    {
        CheckForActivation();
        Release();
    }

    private void Release()
    {
        _currentAngle = Mathf.Clamp(_currentAngle + releaseSpeed * Time.deltaTime, minAngle, maxAngle);
        leverPivot.localRotation = Quaternion.Euler(_currentAngle, 0f, 0f);
    }

    public void PushDown()
    {
        _currentAngle = Mathf.Clamp(_currentAngle + (-releaseSpeed - pushDownSpeed) * Time.deltaTime, minAngle, maxAngle);
        leverPivot.localRotation = Quaternion.Euler(_currentAngle, 0f, 0f);
    }

    private void CheckForActivation()
    {
        if (leverPivot.localEulerAngles.x < activationAngle)
        {
            isActivated = true;
        }
        else
        {
            isActivated = false;
        }
    }
}