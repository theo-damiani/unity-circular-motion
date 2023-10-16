
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveUpDownFromVariable))]
public class MoveUpDownFromVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MoveUpDownFromVariable script = (MoveUpDownFromVariable) target;

        using (new EditorGUI.DisabledScope(true))
        {
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MoveUpDownFromVariable)target), typeof(MoveUpDownFromVariable), false);
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("moveTimeReference"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("timeMode"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("yOffset"));

        script.vector3Binded = (Vector3Variable)EditorGUILayout.ObjectField("Vector3 Binded", script.vector3Binded, typeof(Vector3Variable), false);

        serializedObject.ApplyModifiedProperties();
    }
}
