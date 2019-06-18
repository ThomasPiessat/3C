#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    private Object editorfield;

    private Material material;

    private SerializedObject soTarget;

    private SerializedProperty stringVar1;
    private SerializedProperty stringVar2;

    private bool foldout = false;

    private void OnEnable()
    {
        stringVar1 = serializedObject.FindProperty("m_values");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.BeginVertical();

        GUILayout.Label("ItemSpec", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("Inc"))
        {
            stringVar1.intValue++;
        }

        EditorGUILayout.PropertyField(stringVar1);

        editorfield = EditorGUILayout.ObjectField(editorfield, typeof(Object), false);
        foldout = EditorGUILayout.Foldout(foldout, new GUIContent("List"), true);

        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }

}

#endif