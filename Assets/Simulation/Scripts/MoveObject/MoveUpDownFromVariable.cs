using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownFromVariable : MoveObjectUpDown
{
    public FloatReference floatReference;
    public override void MoveUp()
    {
        MoveAlongY(floatReference.Value);
    }

    public override void MoveDown()
    {
        MoveAlongY(floatReference.Value);
    }
}
