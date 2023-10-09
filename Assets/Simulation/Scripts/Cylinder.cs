using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private float xzScale = 0.3f;
    [SerializeField] private float yScaleOffset = 0.1f;
    public void SetCylinder(Vector3Variable topPosition)
    {
        transform.localScale = new Vector3(xzScale, topPosition.Value.y/2+yScaleOffset, xzScale);
        transform.localPosition = new Vector3(0f, topPosition.Value.y/2+yScaleOffset, 0f);
    }
}
