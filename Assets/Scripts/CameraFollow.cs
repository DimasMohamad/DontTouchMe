using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smhoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smhoothedPosition;

        //transform.LookAt(Target);
    }

}
