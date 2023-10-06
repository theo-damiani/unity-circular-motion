using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveUpDownFromVariable))]
public class MoveUpDownFromVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MoveUpDownFromVariable script = (MoveUpDownFromVariable) target;

        //script.floatReference = (FloatReference) EditorGUILayout.ObjectField("Y Up Value :", script.floatReference, typeof(FloatReference), true);
        //script.floatReference = (FloatReference) EditorGUILayout.ObjectField("", typeof(FloatReference));
    }
}
