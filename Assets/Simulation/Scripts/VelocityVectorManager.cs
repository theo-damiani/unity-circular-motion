using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVectorManager : MonoBehaviour
{
    [SerializeField] private Vector velocityVector;
    [SerializeField] private Vector3Variable velocityVariable;
    [SerializeField] private CircularMotion motion;    
    [SerializeField] private Transform transform1;    
    public void SetVelocityFromVector()
    {
        velocityVariable.Value = velocityVector.components;
    }

    public void SetVectorFromVelocity()
    {
        velocityVector.components = velocityVariable.Value;
        velocityVector.Redraw();
    }

    public void SetVectorFromCircularMotion()
    {
        Vector3 radius = motion.center.Value - transform1.localPosition;
        Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        Vector3 velocity = motion.angularVelocityInit*radius.magnitude*velocityDirectionInit;

        velocityVariable.Value = velocity;
    }
}
