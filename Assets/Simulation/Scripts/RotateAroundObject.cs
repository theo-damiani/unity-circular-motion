using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    [SerializeField] private CircularMotion circularMotion;
    [SerializeField] private Vector3Variable pivotPoint;
    public bool IsRotating {get; set;}
    void FixedUpdate()
    {
        if (IsRotating)
            transform.RotateAround(pivotPoint.Value, Vector3.up, circularMotion.angularVelocityInit);
    }
}
