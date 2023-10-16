using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownFromVariable : MoveObjectUpDown
{
    public FloatReference moveTimeReference;
    public FloatReference yOffset;

    public override void Start()
    {
        base.Start();
        moveTime = moveTimeReference.Value;
    }
    public override void MoveUp()
    {
        MoveAlongY(transform.localPosition.y, yOffset.Value);
    }

    public override void MoveDown()
    {
        MoveAlongY(transform.localPosition.y, 0);
    }
}
