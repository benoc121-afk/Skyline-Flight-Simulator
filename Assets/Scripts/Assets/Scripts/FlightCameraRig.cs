using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{
    public Transform aircraft;
    public Vector3 cameraOffset = new Vector3(0f, 4f, -12f);
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;
    public float lookAhead = 10f;

    void LateUpdate()
    {
        if (aircraft == null) return;

        Vector3 targetPosition =
            aircraft.TransformPoint(cameraOffset);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        Vector3 lookTarget =
            aircraft.position + aircraft.forward * lookAhead;

        Quaternion targetRotation = Quaternion.LookRotation(
            lookTarget - transform.position,
            aircraft.up
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}