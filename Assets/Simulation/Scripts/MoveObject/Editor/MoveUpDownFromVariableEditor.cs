
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveUpDownFromVariable))]
public class MoveUpDownFromVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // MoveUpDownFromVariable script = (MoveUpDownFromVariable) target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("floatReference"));
    }
}
