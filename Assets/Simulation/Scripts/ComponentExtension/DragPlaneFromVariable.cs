using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableVector))]
public class DragPlaneFromVariable : MonoBehaviour
{
    [Header("Drag Plane Variable")]
    [SerializeField] private Vector3Variable planePosition;
    [SerializeField] private Vector3Variable planeNormal;

    public void DefineDragPlaneFromVariable()
    {
        GetComponent<DraggableVector>().DefineDragPlane(planeNormal.Value, planePosition.Value);
    }
}
