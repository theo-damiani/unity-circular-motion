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
        MoveAlongY(yUp, yDown);
    }

    public virtual void MoveDown()
    {
        MoveAlongY(yDown, yUp);
    }

    protected void MoveAlongY(float startY, float targetY)
    {
        base.MoveToAlongAxis(startY, targetY);
    }
}
