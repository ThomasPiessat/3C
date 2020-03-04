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
    private GameObject PrefabSpell;
    private Sprite IconSpell;
    private string NameSpell;
    private int ManaCostSpell;
    private float CooldownSpell;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.BeginVertical();

        GUILayout.Label("SpellSpec", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("PrefabSpell");
        PrefabSpell = (GameObject)EditorGUILayout.ObjectField(PrefabSpell, typeof(GameObject), false);
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

        GUILayout.EndVertical();
        //base.OnInspectorGUI();


    }
}

#endif