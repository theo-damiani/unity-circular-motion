using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RopeData", menuName = "Components / Rope")]
public class RopeData : ScriptableObject
{
    public GameObject ropeSegmentPrefab;

    [Header("Rope Variables Definition")]
    [SerializeField] private float ropeLength;
    [field: SerializeField] public Vector3 RopeSegmentScale { get; private set; }
    [field: SerializeField] public Vector3 RopeDirectionInit { get; set; } // Direction where each segment will be build at Instantiation.
    [SerializeField] public bool RopeUseGravity;

    [Header("On Update Events Definition")]
    [SerializeField] private GameEvent OnRopeLengthUpdate;

    /* *********** Properties *********** */

    public float RopeLength 
    {
        get {return ropeLength;}

        set
        {
            ropeLength = value;
            if (OnRopeLengthUpdate)
                OnRopeLengthUpdate.Raise();
        }
    }
}
