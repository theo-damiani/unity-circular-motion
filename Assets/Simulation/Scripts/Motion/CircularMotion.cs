using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "circularMotion", menuName="Motion / Circular Motion")]
public class CircularMotion : Motion
{
    public float angularVelocityInit;
    public Vector3Reference center;
    [SerializeField] private bool useUnityPhysics;
    [SerializeField] private Vector3Variable velocityVariable;
    private float currentAngularVelocity;

    public override void ApplyMotion(Rigidbody rigidbody)
    {
        if (velocityVariable!=null)
        {
            SetVelocityVariable(rigidbody);
        }

        if (useUnityPhysics)
        {
            ApplyWithUnityPhysics(rigidbody);
        }
        else
        {
            ApplyWithCustomComputation(rigidbody);
        }
        
    }

    private void ApplyWithUnityPhysics(Rigidbody rigidbody)
    {
        Vector3 radius = center.Value - rigidbody.transform.localPosition;
        if (!isMotionInit)
        {
            Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
            Vector3 velocity = angularVelocityInit*radius.magnitude*velocityDirectionInit;
            rigidbody.AddForce(velocity, ForceMode.VelocityChange);

            isMotionInit = true;
            currentAngularVelocity = angularVelocityInit;
        }
        // Centripetal Force:
        Vector3 centripetalAcceleration = currentAngularVelocity * currentAngularVelocity * radius;

        rigidbody.AddForce(centripetalAcceleration, ForceMode.Acceleration);
    }

    private void ApplyWithCustomComputation(Rigidbody rigidbody)
    {
        Vector3 radius = center.Value - rigidbody.transform.localPosition;
        rigidbody.transform.RotateAround(center.Value, Vector3.up, currentAngularVelocity*Mathf.Rad2Deg*Time.fixedDeltaTime);
    }

    public void SetVelocityVariable(Rigidbody rigidbody)
    {
        Vector3 radius = center.Value - rigidbody.transform.localPosition;
        Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        Vector3 velocity = currentAngularVelocity*radius.magnitude*velocityDirectionInit;

        velocityVariable.Value = velocity;
    }
}
