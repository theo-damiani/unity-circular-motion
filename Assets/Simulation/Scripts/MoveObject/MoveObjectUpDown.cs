using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjectUpDown : MoveObject
{
    [SerializeField] private float yDown;
    [SerializeField] private float yUp;

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
        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition = transform.localPosition;
        endPosition.y = targetY;
        base.MoveTo(startPosition, endPosition);
    }
}
