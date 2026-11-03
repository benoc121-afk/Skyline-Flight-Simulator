using UnityEngine;

public class LandingZone : MonoBehaviour
{
    public string runwayName = "Emergency Runway";
    public float maxLandingSpeed = 80f;
    public float maxLandingAngle = 10f;
    public float maxVerticalSpeed = 5f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody aircraft = other.attachedRigidbody;

        if (aircraft == null) return;

        float speed = aircraft.linearVelocity.magnitude;
        float verticalSpeed = Mathf.Abs(
            Vector3.Dot(aircraft.linearVelocity, transform.up)
        );

        float landingAngle = Vector3.Angle(
            aircraft.transform.forward,
            transform.forward
        );

        bool safeLanding =
            speed <= maxLandingSpeed &&
            verticalSpeed <= maxVerticalSpeed &&
            landingAngle <= maxLandingAngle;

        if (safeLanding)
        {
            Debug.Log("Successful landing at " + runwayName);
        }
        else
        {
            Debug.Log("Landing failed at " + runwayName);
        }
    }
}