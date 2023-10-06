using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MotionManager : MonoBehaviour
{
    [SerializeField] private Motion motion;
    [SerializeField] private bool applyMotion;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyMotion)
        {
            motion.ApplyMotion(GetComponent<Rigidbody>());
        }
    }

    public void StartMotion()
    {
        motion.isMotionInit = false;
        applyMotion = true;
    }

    public void StopMotion()
    {
        applyMotion = false;
    }
}
