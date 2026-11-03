using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlightController : MonoBehaviour
{
    [Header("Aircraft Settings")]
    public float enginePower = 12000f;
    public float liftPower = 0.8f;
    public float drag = 0.02f;
    public float pitchPower = 5000f;
    public float rollPower = 6000f;
    public float yawPower = 2000f;

    [Header("Flight Inputs")]
    [Range(0f, 1f)] public float throttle = 0.5f;
    [Range(-1f, 1f)] public float pitch;
    [Range(-1f, 1f)] public float roll;
    [Range(-1f, 1f)] public float yaw;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = 12000f;
        rb.linearDamping = drag;
        rb.angularDamping = 1f;
    }

    void FixedUpdate()
    {
        float speed = rb.linearVelocity.magnitude;

        // Engine thrust
        rb.AddForce(
            transform.forward * enginePower * throttle,
            ForceMode.Force
        );

        // Simplified aerodynamic lift
        float lift = speed * speed * liftPower;
        rb.AddForce(
            transform.up * lift,
            ForceMode.Force
        );

        // Aircraft control forces
        rb.AddTorque(
            transform.right * pitch * pitchPower,
            ForceMode.Force
        );

        rb.AddTorque(
            -transform.forward * roll * rollPower,
            ForceMode.Force
        );

        rb.AddTorque(
            transform.up * yaw * yawPower,
            ForceMode.Force
        );
    }

    public void SetThrottle(float value)
    {
        throttle = Mathf.Clamp01(value);
    }

    public void SetPitch(float value)
    {
        pitch = Mathf.Clamp(value, -1f, 1f);
    }

    public void SetRoll(float value)
    {
        roll = Mathf.Clamp(value, -1f, 1f);
    }

    public void SetYaw(float value)
    {
        yaw = Mathf.Clamp(value, -1f, 1f);
    }
}