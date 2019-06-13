using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThirdPersonCamera))]
[CanEditMultipleObjects]
public class ThirdPersonCameraEditor : Editor
{
    private GUISkin m_skin = null;
    private ThirdPersonCamera m_tpsCamera = null;

    public override void OnInspectorGUI()
    {
        if (!m_skin)
        {
            m_skin = Resources.Load("m_skin") as GUISkin;
        }
        GUI.skin = m_skin;

        GUILayout.BeginVertical("CAMERA");
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();

        base.OnInspectorGUI();

        GUILayout.EndVertical();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

    }
}
