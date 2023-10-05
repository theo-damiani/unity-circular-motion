using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveObject : MonoBehaviour
{
    public void ApplyVelocityChange(Vector3 velocity)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.velocity = Vector3.zero;
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }
}
