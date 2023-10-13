using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "circularMotion", menuName="Motion / Circular Motion")]
public class CircularMotion : Motion
{
    public float angularVelocityInit; // Used if velocityVariable is null;
    public Vector3Reference center;
    [SerializeField] private bool useUnityPhysics;
    [SerializeField] private Vector3Variable velocityVariable;
    public float currentAngularVelocity;

    public override void ApplyMotion(Rigidbody rigidbody)
    {
        if (!isMotionInit)
        {
            if (useUnityPhysics)
            {
                InitUnityPhysics(rigidbody);
            }
            else
            {
                InitCustomPhysics(rigidbody);
            }
            isMotionInit = true;
        }

        if (useUnityPhysics)
        {
            ApplyWithUnityPhysics(rigidbody);
        }
        else
        {
            ApplyWithCustomComputation(rigidbody);
        }
        
        if (velocityVariable!=null) // Update velocity variable
        {
            Vector3 radius = GetRadius(rigidbody);
            Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
            velocityVariable.Value = currentAngularVelocity*radius.magnitude*velocityDirectionInit;;
        }
    }

    private void ApplyWithUnityPhysics(Rigidbody rigidbody)
    {
        // Centripetal Force:
        Vector3 centripetalAcceleration = currentAngularVelocity * currentAngularVelocity * GetRadius(rigidbody);
        rigidbody.AddForce(centripetalAcceleration, ForceMode.Acceleration);
    }

    private void ApplyWithCustomComputation(Rigidbody rigidbody)
    {
        rigidbody.transform.RotateAround(center.Value, Vector3.up, currentAngularVelocity*Mathf.Rad2Deg*Time.fixedDeltaTime);
    }

    private void InitUnityPhysics(Rigidbody rigidbody)
    {
        rigidbody.AddForce(GetVelocity(rigidbody), ForceMode.VelocityChange);

        currentAngularVelocity = GetAngularVelocity(rigidbody);
    }

    private void InitCustomPhysics(Rigidbody rigidbody)
    {
        currentAngularVelocity = GetAngularVelocity(rigidbody);
    }

    private Vector3 GetVelocity(Rigidbody rigidbody)
    {
        if (velocityVariable==null)
        {
            Vector3 radius = GetRadius(rigidbody);
            Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
            return angularVelocityInit*radius.magnitude*velocityDirectionInit;
        }
        else
        {
            return velocityVariable.Value;
        }
    }

    private float GetAngularVelocity(Rigidbody rigidbody)
    {
        if (velocityVariable==null)
        {
            return angularVelocityInit;
        }
        else
        {
            Vector3 radius = GetRadius(rigidbody);
            float velocitySign = Mathf.Sign(Vector3.Cross(velocityVariable.Value, radius).y);
            return velocitySign * velocityVariable.Value.magnitude / radius.magnitude;
        }
    }

    private Vector3 GetRadius(Rigidbody rigidbody)
    {
        return center.Value - rigidbody.transform.localPosition;
    }
}
