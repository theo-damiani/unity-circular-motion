using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingBall : MonoBehaviour
{
    [SerializeField] Vector velocityVector;
    [SerializeField] SimulationData simulationData;
    public void ApplyVelocityVector()
    {
        if (simulationData.useCircularMotion)
        {
            return;
        }

        Vector3 velocity = velocityVector.components;

        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.velocity = Vector3.zero;
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }
}
