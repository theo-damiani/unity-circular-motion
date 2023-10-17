using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "uniformMotion", menuName="Motion / Uniform Motion")]
public class UniformMotion : Motion
{
    public Vector3Reference velocity;
    public override void ApplyMotion(Rigidbody rigidbody)
    {
        if (!isMotionInit)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(velocity.Value, ForceMode.VelocityChange);
            isMotionInit = true;
        }
        // No Forces to apply!
    }
}
