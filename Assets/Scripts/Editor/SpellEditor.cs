#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Spells), true)]
[CanEditMultipleObjects]
public class SpellEditor : Editor
{
    SerializedProperty po;
    private GameObject PrefabSpell;
    private Sprite IconSpell;
    private string NameSpell;
    private int ManaCostSpell;
    private float CooldownSpell;

    private int toolBaarint = 0;
    string[] toolbarSettings = { "Couille1", "BurneG", "BurneD" };

    Spells fb;


    public void OnEnable()
    {
        po = serializedObject.FindProperty("m_Prefab");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.BeginVertical();

        GUILayout.Label("SpellSpec", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("PrefabSpell");
        PrefabSpell = (GameObject)EditorGUILayout.ObjectField(PrefabSpell, typeof(GameObject), false);
        EditorGUILayout.ObjectField(po, new GUIContent("m_Prefab"));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("IconSpell");
        IconSpell = (Sprite)EditorGUILayout.ObjectField(IconSpell, typeof(Sprite), false);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("NameSpell");
        NameSpell = EditorGUILayout.TextField(NameSpell);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("NameSpell");
        ManaCostSpell = EditorGUILayout.IntField(ManaCostSpell);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("CooldownSpell");
        CooldownSpell = EditorGUILayout.FloatField(CooldownSpell);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        toolBaarint = GUILayout.Toolbar(toolBaarint, toolbarSettings);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Bite"))
        {
            fb = (Spells)target;
            fb.TestForButtonEditor();
        }
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
        //base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }
}

#endif