using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVectorManager : MonoBehaviour
{
    [SerializeField] private Vector velocityVector;
    [SerializeField] private UniformMotion uniformMotion;
    
    public void SetVelocityFromVector()
    {
        uniformMotion.velocity = velocityVector.components;
    }
}
