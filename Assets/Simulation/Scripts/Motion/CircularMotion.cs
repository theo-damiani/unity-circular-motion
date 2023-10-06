using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "circularMotion", menuName="Motion / Circular Motion")]
public class CircularMotion : Motion
{
    public float angularVelocityInit;
    public Vector3 center;
    private float currentAngularVelocity;

    public override void ApplyMotion(Rigidbody rigidbody)
    {
        Vector3 radius = center - rigidbody.transform.localPosition;
        if (!isMotionInit)
        {
            Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
            rigidbody.AddForce(angularVelocityInit*radius.magnitude*velocityDirectionInit, ForceMode.VelocityChange);

            isMotionInit = true;
            currentAngularVelocity = angularVelocityInit;
        }
        // Centripetal Force:
        Vector3 centripetalAcceleration = currentAngularVelocity * currentAngularVelocity * radius;

        rigidbody.AddForce(centripetalAcceleration, ForceMode.Acceleration);
    }
}
