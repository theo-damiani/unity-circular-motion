using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Motion : ScriptableObject, IMotion
{
    public bool isMotionInit;
    public abstract void ApplyMotion(Rigidbody rigidbody);
    public virtual void InitMotion()
    {
        isMotionInit = false;
    }
}
