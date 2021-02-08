using Lean.Touch;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Rigidbody movingPlatform;
    public float limit = 15;
    public float sensitivity = 1;

    private void Awake()
    {
        LeanTouch.OnFingerUpdate += OnFingerUpdate;
    }

    private void OnFingerUpdate(LeanFinger finger)
    {
        Vector2 delta = finger.ScaledDelta;
        float xDelta = delta.y;
        float zDelta = -delta.x;
        Vector3 rotation = movingPlatform.rotation.eulerAngles;
        rotation.x += xDelta * Time.deltaTime * sensitivity;
        rotation.z += zDelta * Time.deltaTime * sensitivity;

        rotation.x = LimitRotation(rotation.x);
        rotation.z = LimitRotation(rotation.z);
        
        movingPlatform.MoveRotation(Quaternion.Euler(rotation));
    }

    private float LimitRotation(float currentAngle)
    {
        float result = currentAngle;
        if (currentAngle > 180){
            if(currentAngle < 360 - limit) result = 360 - limit; // quaternion => always > 0 angles
        }
        else if (currentAngle > limit) result = limit;

        return result;
    }
}
