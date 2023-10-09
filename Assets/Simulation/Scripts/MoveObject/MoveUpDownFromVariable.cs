using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownFromVariable : MoveObjectUpDown
{
    public FloatReference moveTimeReference;
    public FloatReference yUpReference;
    public FloatReference yDownReference;

    void Start()
    {
        moveTime = moveTimeReference.Value;
    }
    public override void MoveUp()
    {
        MoveAlongY(yUpReference.Value);
    }

    public override void MoveDown()
    {
        MoveAlongY(yDownReference.Value);
    }
}
