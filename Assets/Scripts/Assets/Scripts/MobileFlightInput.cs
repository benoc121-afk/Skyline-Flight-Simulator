using UnityEngine;

public class MobileFlightInput : MonoBehaviour
{
    public FlightController aircraft;

    public void Pitch(float value)
    {
        if (aircraft != null)
            aircraft.SetPitch(value);
    }

    public void Roll(float value)
    {
        if (aircraft != null)
            aircraft.SetRoll(value);
    }

    public void Yaw(float value)
    {
        if (aircraft != null)
            aircraft.SetYaw(value);
    }

    public void Throttle(float value)
    {
        if (aircraft != null)
            aircraft.SetThrottle(value);
    }

    public void ResetControls()
    {
        if (aircraft == null) return;

        aircraft.SetPitch(0f);
        aircraft.SetRoll(0f);
        aircraft.SetYaw(0f);
    }
}