using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVectorManager : MonoBehaviour
{
    [SerializeField] private DraggableVector draggableVector;
    [SerializeField] private Vector3Variable velocityVariable;
    [SerializeField] private CircularMotion motion;    
    [SerializeField] private Transform transform1;    

    public void SetVectorFromVelocity()
    {
        if (!draggableVector.IsDragged())
        {   
            // If vector is dragged, no need to redraw it.
            draggableVector.Redraw();
        }
    }

    public void SetVectorFromCircularMotion()
    {
        Vector3 velocity = motion.GetVelocityFromAngularSpeed(transform1, true);

        // Vector3 radius = motion.center.Value - transform1.localPosition;
        // Vector3 velocityDirectionInit = (Quaternion.Euler(0, -90, 0) * radius).normalized;
        // Vector3 velocity = motion.angularVelocityInit*radius.magnitude*velocityDirectionInit;
        // velocity.y = 0;

        draggableVector.components.Value = velocity;
        // velocityVector.Redraw();
    }
}
