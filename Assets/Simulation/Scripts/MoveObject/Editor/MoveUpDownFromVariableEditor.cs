
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveUpDownFromVariable))]
public class MoveUpDownFromVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // MoveUpDownFromVariable script = (MoveUpDownFromVariable) target;

        using (new EditorGUI.DisabledScope(true))
        {
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MoveUpDownFromVariable)target), typeof(MoveUpDownFromVariable), false);
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("floatReference"));
    }
}
