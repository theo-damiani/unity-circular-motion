using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjectUpDown : MoveObject
{
    [SerializeField] private float yUp;
    [SerializeField] private float yDown;

    public virtual void MoveUp()
    {
        MoveAlongY(yUp);
    }

    public virtual void MoveDown()
    {
        MoveAlongY(yDown);
    }

    protected void MoveAlongY(float targetY)
    {
        base.MoveToAlongAxis(targetY, Vector3.up);
    }
}
