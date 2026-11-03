using UnityEngine;

public class AircraftSystems : MonoBehaviour
{
    [Header("Engine")]
    public bool engineRunning = true;
    public float engineHealth = 100f;

    [Header("Fuel")]
    public float fuel = 100f;
    public float fuelConsumption = 0.02f;

    [Header("Aircraft Configuration")]
    public bool landingGearDown = true;
    public float flapPosition = 0f;
    public bool parkingBrake = true;

    [Header("Connected Flight Controller")]
    public FlightController aircraft;

    void Update()
    {
        if (aircraft == null) return;

        if (!engineRunning || fuel <= 0f || engineHealth <= 0f)
        {
            engineRunning = false;
            aircraft.SetThrottle(0f);
        }
        else
        {
            fuel -= aircraft.throttle * fuelConsumption
                    * Time.deltaTime;
            fuel = Mathf.Max(0f, fuel);
        }
    }

    public void StartEngine()
    {
        if (fuel > 0f && engineHealth > 0f)
            engineRunning = true;
    }

    public void StopEngine()
    {
        engineRunning = false;

        if (aircraft != null)
            aircraft.SetThrottle(0f);
    }

    public void TriggerEngineFailure()
    {
        engineHealth = 0f;
        StopEngine();
    }

    public void ToggleLandingGear()
    {
        landingGearDown = !landingGearDown;
    }

    public void SetFlaps(float value)
    {
        flapPosition = Mathf.Clamp01(value);
    }

    public void ToggleParkingBrake()
    {
        parkingBrake = !parkingBrake;
    }
}