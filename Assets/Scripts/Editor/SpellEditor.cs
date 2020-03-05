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

    bool m_show = false;

    Spells fb;
    bool showItem = true;

    public void OnEnable()
    {
        po = serializedObject.FindProperty("m_Prefab");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        fb = (Spells)target;

        serializedObject.Update();
        GUILayout.BeginVertical();

        GUILayout.Label("SpellSpec", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        m_show = GUILayout.Toggle(m_show, "Show");
        if (m_show)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("PrefabSpell", GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            PrefabSpell = (GameObject)EditorGUILayout.ObjectField(PrefabSpell, typeof(GameObject), false);
            //EditorGUILayout.ObjectField(po, new GUIContent("m_Prefab"));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("IconSpell", GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            IconSpell = (Sprite)EditorGUILayout.ObjectField(IconSpell, typeof(Sprite), false);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("NameSpell", GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            NameSpell = EditorGUILayout.TextField(NameSpell);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("ManaCost", GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            ManaCostSpell = EditorGUILayout.IntField(ManaCostSpell);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("CooldownSpell", GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            CooldownSpell = EditorGUILayout.FloatField(CooldownSpell);
            GUILayout.EndHorizontal();
        }

        Editor ItemEditor = Editor.CreateEditor(fb.m_test);
        if (ItemEditor != null)
        {
            GUILayout.Label("Item", EditorStyles.boldLabel);

            ItemEditor.OnInspectorGUI();
        }

        //GUILayout.BeginHorizontal(EditorStyles.toolbar);
        //toolBaarint = GUILayout.Toolbar(toolBaarint, toolbarSettings);
        //GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Bite"))
        {
            //Ensuite tu peut utiliser les fonctions "PUBLIC" de la target
            fb.TestForButtonEditor();
        }
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
        //base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }
}

#endif