using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "simulationData", menuName = "simulation / data")]
public class SimulationData : ScriptableObject
{
    public bool useCircularMotion;
    public float YCenterWithOnGravity;
    [SerializeField] private GameEvent gameEventOnPlaneCurrentPositionUpdate;
    [SerializeField] private Vector3Variable planeCurrentPosition;
    public Vector3 PlaneCurrentPosition 
    {
        get {
            return planeCurrentPosition.Value;
        }

        set {
            planeCurrentPosition.Value = value;
            gameEventOnPlaneCurrentPositionUpdate.Raise();
        }
    }

    public void SetuseCircularMotion(bool value)
    {
        useCircularMotion = value;
    }
}
