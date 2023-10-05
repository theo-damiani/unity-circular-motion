using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UniformMotionManager : MonoBehaviour
{
    [SerializeField] private UniformMotion motion;

    [SerializeField] private bool useVectorForInitVelocity;
    [SerializeField] private Vector velocityVector;
    [SerializeField] private bool applyMotion;

    // Start is called before the first frame update
    void Start()
    {
        if (useVectorForInitVelocity)
        {
            SetInitialVelocityFromVector();
        }
    }

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
        SetInitialVelocityFromVector();
        motion.isMotionInit = false;
        applyMotion = true;
    }

    private void SetInitialVelocityFromVector()
    {
        motion.velocity = velocityVector.components;
    }
}
