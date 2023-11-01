using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VectorRigidbodyBind : MonoBehaviour
{
    [SerializeField] private Vector3Variable velocityVector;
    [SerializeField] private DraggableVector vector;
    [SerializeField] private BoolVariable centralForceIsActive;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (centralForceIsActive.Value)
        {
            SetVectorVelocity();
        }
    }

    public void OnEnable()
    {
        VectorClickZone.OnZoneMouseUp += SetRigidbodyVelocity;
    }

    private void OnDisable()
    {
        VectorClickZone.OnZoneMouseUp -= SetRigidbodyVelocity;
    }

    public void SetRigidbodyVelocity(VectorClickZone clickZone)
    {
        if (!rb.isKinematic)
            rb.velocity = velocityVector.Value;
    }

    public void SetVectorVelocity()
    {
        if (velocityVector.Value == rb.velocity)
        {
            return;
        }
        velocityVector.Value = rb.velocity;
        vector.Redraw();
    }
}
