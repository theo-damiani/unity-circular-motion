using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableVector))]
public class DragPlaneFromVariable : MonoBehaviour
{
    [Header("Drag Plane Variable")]
    [SerializeField] private Vector3Reference planePosition;
    [SerializeField] private Transform transformGameObject;
    [SerializeField] private Vector3Reference planeNormal;

    public void DefineDragPlaneFromVariable()
    {
        GetComponent<DraggableVector>().DefineDragPlane(planeNormal.Value, planePosition.Value);
    }

    public void DefineDragPlaneFromTransform()
    {
        GetComponent<DraggableVector>().DefineDragPlane(planeNormal.Value, transformGameObject.localPosition);
    }
}
