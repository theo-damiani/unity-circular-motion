using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "centralMotion", menuName="Motion / Central Motion")]
public class CentralMotion : Motion
{
    public Vector3Reference center;
    public FloatReference angularvelocity;
    public override void InitMotion(Rigidbody rigidbody)
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(GetVelocityFromAngularSpeed(rigidbody.transform), ForceMode.VelocityChange);
    }

    public override void ApplyMotion(Rigidbody rigidbody)
    {
        ApplyWithUnityPhysics(rigidbody);
    }

    private void ApplyWithUnityPhysics(Rigidbody rigidbody)
    {
        // Centripetal Force:
        Vector3 centripetalAcceleration = angularvelocity.Value * angularvelocity.Value * GetRadius(rigidbody.transform);
        rigidbody.AddForce(centripetalAcceleration, ForceMode.Acceleration);
    }

    public Vector3 GetVelocityFromAngularSpeed(Transform transform)
    {
        Vector3 radius = GetRadius(transform);
        Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        Vector3 newVelocity = angularvelocity.Value*radius.magnitude*velocityDirectionInit;
        newVelocity.y = 0;
        return newVelocity;
    }

    private Vector3 GetRadius(Transform t)
    {
        return center.Value - t.localPosition;
    }
}
