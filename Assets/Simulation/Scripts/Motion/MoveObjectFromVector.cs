using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFromVector : MoveObject
{
    [SerializeField] Vector3 velocity;

    public void ApplyVelocityChange()
    {
        ApplyVelocityChange(velocity);
    }
}
