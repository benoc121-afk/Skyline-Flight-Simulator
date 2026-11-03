using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public enum MissionType
    {
        FreeFlight,
        EmergencyLanding
    }

    public MissionType currentMission =
        MissionType.FreeFlight;

    public AircraftSystems aircraftSystems;

    public bool missionActive;
    public bool missionCompleted;

    public void StartFreeFlight()
    {
        currentMission = MissionType.FreeFlight;
        missionActive = true;
        missionCompleted = false;

        Debug.Log("Free flight started!");
    }

    public void StartEmergencyLanding()
    {
        currentMission = MissionType.EmergencyLanding;
        missionActive = true;
        missionCompleted = false;

        if (aircraftSystems != null)
            aircraftSystems.TriggerEngineFailure();

        Debug.Log("Emergency landing mission started!");
    }

    public void CompleteMission()
    {
        if (!missionActive) return;

        missionCompleted = true;
        missionActive = false;

        Debug.Log("Mission completed!");
    }

    public void FailMission()
    {
        missionActive = false;
        missionCompleted = false;

        Debug.Log("Mission failed!");
    }
}