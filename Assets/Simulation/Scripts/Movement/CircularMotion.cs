using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField] private float angularVelocityInit;
    [SerializeField] private Vector3 center;
    private Rigidbody rigidbody;

    private float currentAngularVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 radius = center - transform.localPosition;
        Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        rigidbody.AddForce(angularVelocityInit*radius.magnitude*velocityDirectionInit, ForceMode.VelocityChange);

        currentAngularVelocity = angularVelocityInit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forceDirection = center - transform.localPosition;
        Vector3 centripetalAcceleration = currentAngularVelocity * currentAngularVelocity * forceDirection;

        rigidbody.AddForce(centripetalAcceleration, ForceMode.Acceleration);
    }
}
