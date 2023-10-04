using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "simulationData", menuName = "simulation / data")]
public class SimulationData : ScriptableObject
{
    public Vector3 planeXZCenterWithOnGravity;
    [SerializeField] private GameEvent gameEventOnPlaneCurrentPositionUpdate;
    private Vector3 planeXZCurrentPosition;
    public Vector3 PlaneXZCurrentPosition 
    {
        get {
            return planeXZCurrentPosition;
        }

        set {
            planeXZCurrentPosition = value;
            gameEventOnPlaneCurrentPositionUpdate.Raise();
        }
    }
}
