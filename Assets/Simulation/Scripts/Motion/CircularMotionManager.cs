using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CircularMotionManager : MonoBehaviour
{
    [SerializeField] private CircularMotion motion;
    [SerializeField] private Vector3Variable pivotPoint;
    [SerializeField] private bool applyMotion;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyMotion)
        {
            motion.ApplyMotion(GetComponent<Rigidbody>());
        }
    }

    public void SetAndApplyMotion()
    {
        motion.center = pivotPoint.Value;
        motion.isMotionInit = false;
        applyMotion = true;
    }

    public void StopMotion()
    {
        applyMotion = false;
    }
}
