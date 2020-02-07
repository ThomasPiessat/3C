using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//https://www.youtube.com/watch?v=-tbHQZGKM_w&list=PL4CCSwmU04Mih3WUYhJYYXvAReqpoaKob

[CustomEditor(typeof(TestEnemy))]
[CanEditMultipleObjects]
public class TestEnemyEditor : Editor
{
    SerializedProperty HealthProp;
    SerializedProperty AttackProp;
    SerializedProperty ArmorProp;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        HealthProp = serializedObject.FindProperty("Health");
        AttackProp = serializedObject.FindProperty("Attack");
        ArmorProp = serializedObject.FindProperty("Armor");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();

        EditorGUILayout.Slider(HealthProp, 0.0f, 100.0f, new GUIContent("Health"));
        if (!HealthProp.hasMultipleDifferentValues)
            ProgressBar(HealthProp.floatValue / 100.0f, "Health");

        // Show the custom GUI controls.
        EditorGUILayout.IntSlider(AttackProp, 0, 100, new GUIContent("Attack"));

        // Only show the damage progress bar if all the objects have the same damage value:
        if (!AttackProp.hasMultipleDifferentValues)
            ProgressBar(AttackProp.intValue / 100.0f, "Attack");

        EditorGUILayout.IntSlider(ArmorProp, 0, 100, new GUIContent("Armor"));

        // Only show the armor progress bar if all the objects have the same armor value:
        if (!ArmorProp.hasMultipleDifferentValues)
            ProgressBar(ArmorProp.intValue / 100.0f, "Armor");

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
