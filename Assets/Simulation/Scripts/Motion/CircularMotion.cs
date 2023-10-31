using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion
{
    public float angularVelocityInit; // Used if velocityVariable is null;
    public Vector3Reference center;
    [SerializeField] private bool useUnityPhysics;
    [SerializeField] private Vector3Variable velocityVariable;
    public float currentAngularVelocity;

    // public void ApplyMotion(Rigidbody rigidbody)
    // {
    //     if (!isMotionInit)
    //     {
    //         rigidbody.velocity = Vector3.zero; // Clear all previous forces

    //         if (useUnityPhysics)
    //         {
    //             InitUnityPhysics(rigidbody);
    //         }
    //         else
    //         {
    //             InitCustomPhysics(rigidbody);
    //         }
    //         isMotionInit = true;
    //     }

    //     if (useUnityPhysics)
    //     {
    //         ApplyWithUnityPhysics(rigidbody);
    //     }
    //     else
    //     {
    //         ApplyWithCustomComputation(rigidbody);
    //     }
        
    //     if (velocityVariable!=null) // Update velocity variable
    //     {
    //         velocityVariable.Value = GetVelocityFromAngularSpeed(rigidbody.transform, false);
    //     }
    // }

    public Vector3 GetVelocityFromAngularSpeed(Transform transform, bool useInit)
    {
        Vector3 radius = GetRadius(transform);
        Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        float angularSpeed = useInit ? angularVelocityInit : currentAngularVelocity;
        Vector3 newVelocity = angularSpeed*radius.magnitude*velocityDirectionInit;
        newVelocity.y = 0;
        return newVelocity;
    }

    private void ApplyWithUnityPhysics(Rigidbody rigidbody)
    {
        // Centripetal Force:
        Vector3 centripetalAcceleration = currentAngularVelocity * currentAngularVelocity * GetRadius(rigidbody.transform);
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
            Vector3 radius = GetRadius(rigidbody.transform);
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
            Vector3 radius = GetRadius(rigidbody.transform);
            float velocitySign = Mathf.Sign(Vector3.Cross(velocityVariable.Value, radius).y);

            Vector3 centerWithSameY = new Vector3(center.Value.x, rigidbody.transform.localPosition.y, center.Value.z);
            radius = Vector3.Project(radius, centerWithSameY - rigidbody.transform.localPosition);
            
            return velocitySign * velocityVariable.Value.magnitude / radius.magnitude;
        }
    }

    private Vector3 GetRadius(Transform t)
    {
        return center.Value - t.localPosition;
    }
}
