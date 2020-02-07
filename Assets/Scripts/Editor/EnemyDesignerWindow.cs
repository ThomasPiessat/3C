﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

//https://www.youtube.com/watch?v=Eu4TPhSOEpA&list=PL4CCSwmU04MiCnps1DRmwIEEH7gP9X3qq&index=6
public class EnemyDesignerWindow : EditorWindow
{
    Texture2D HeaderSectionTexture;
    Texture2D CreatureSectionTexture;
    Texture2D MageSectionTexture;
    Texture2D WarriorSectionTexture;

    Color HeaderSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color CreatureSectionColor = new Color(255f, 0.0f, 0.0f, 1f);
    Color MageSectionColor = new Color(0f, 255.0f, 0.0f, 1f);
    Color WarriorSectionColor = new Color(0f, 0.0f, 255.0f, 1f);

    Rect HeaderSection;
    Rect CreatureSection;
    Rect MageSection;
    Rect WarriorSection;

    static CreatureData CreatureData;
    static MageData MageData;
    static WarriorData WarriorData;
    
    public static CreatureData CreatureInfo { get { return CreatureData; } }
    public static MageData MageInfo { get { return MageData; } }
    public static WarriorData WarriorInfo { get { return WarriorData; } }

    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.maxSize = new Vector2(1200, 700);
        window.Show();
    }

    /// <summary>
    /// Similar to Start() / Awake()
    /// </summary>
    private void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        CreatureData = (CreatureData)ScriptableObject.CreateInstance(typeof(CreatureData));
        MageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        WarriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
    }

    /// <summary>
    /// InitialiseTexture2D Values
    /// </summary>
    void InitTextures()
    {
        HeaderSectionTexture = new Texture2D(1, 1);
        HeaderSectionTexture.SetPixel(0, 0, HeaderSectionColor);
        HeaderSectionTexture.Apply();

        CreatureSectionTexture = new Texture2D(1, 1);
        CreatureSectionTexture.SetPixel(0, 0, CreatureSectionColor);
        CreatureSectionTexture.Apply();

        MageSectionTexture = new Texture2D(1, 1);
        MageSectionTexture.SetPixel(0, 0, MageSectionColor);
        MageSectionTexture.Apply();

        WarriorSectionTexture = new Texture2D(1, 1);
        WarriorSectionTexture.SetPixel(0, 0, WarriorSectionColor);
        WarriorSectionTexture.Apply();
    }

    /// <summary>
    /// Similar to any Update function
    /// Not called once per frame. Called 1 or more per interaction
    /// </summary>
    private void OnGUI()
    {
        DrawLayout();
        DrawHeader();
        DrawCreatureSettings();
        DrawMageSettings();
        DrawWarriorSettings();
    }

    /// <summary>
    /// Define Rect values and points textures based on rect
    /// </summary>
    void DrawLayout()
    {
        HeaderSection.x = 0;
        HeaderSection.y = 0;
        HeaderSection.width = Screen.width;
        HeaderSection.height = 50;

        CreatureSection.x = 0;
        CreatureSection.y = 50;
        CreatureSection.width = (Screen.width/3);
        CreatureSection.height = Screen.height;

        MageSection.x = (Screen.width / 3);
        MageSection.y = 50;
        MageSection.width = (Screen.width / 3);
        MageSection.height = Screen.height;

        WarriorSection.x = (Screen.width / 3 * 2);
        WarriorSection.y = 50;
        WarriorSection.width = (Screen.width / 3);
        WarriorSection.height = Screen.height;

        GUI.DrawTexture(HeaderSection, HeaderSectionTexture);
        GUI.DrawTexture(CreatureSection, CreatureSectionTexture);
        GUI.DrawTexture(MageSection, MageSectionTexture);
        GUI.DrawTexture(WarriorSection, WarriorSectionTexture);
    }

    /// <summary>
    /// Draw content of header
    /// </summary>
    void DrawHeader()
    {
        GUILayout.BeginArea(HeaderSection);

        GUILayout.Label("EnemyDesigner");

        GUILayout.EndArea();
    }

    void DrawCreatureSettings()
    {
        GUILayout.BeginArea(CreatureSection);

        GUILayout.Label("Creature");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        CreatureData.Type = (CreatureType)EditorGUILayout.EnumPopup(CreatureData.Type);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    void DrawMageSettings()
    {
        GUILayout.BeginArea(MageSection);

        GUILayout.Label("Mage");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        MageData.Type = (MageType)EditorGUILayout.EnumPopup(MageData.Type);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(WarriorSection);

        GUILayout.Label("Warrior");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        WarriorData.Type = (WarriorType)EditorGUILayout.EnumPopup(WarriorData.Type);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        WarriorData.Weapon = (WarriorWpn)EditorGUILayout.EnumPopup(WarriorData.Weapon);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }


}
