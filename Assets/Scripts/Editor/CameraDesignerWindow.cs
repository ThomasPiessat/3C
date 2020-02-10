using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraDesignerWindow : EditorWindow
{
    #region TEXTURES

    Texture2D HeaderSectionTexture;
    Texture2D CameraFPSSectionTexture;

    Color HeaderSectionColor = new Color(255f, 255f, 255f, 1f);
    Color CameraFPSSectionColor = new Color(255f, 255f, 0f, 1f);

    Rect HeaderSection;
    Rect CameraFPSSection;

    #endregion

    #region PRIVATE STATIC VARIABLES
    
    private static CameraFPSData m_CameraFPSData;

    #endregion

    public static CameraFPSData CameraFPSInfo { get { return m_CameraFPSData; } }

    [MenuItem("Designer/Camera Designer")]
    static void OpenWindow()
    {
        CameraDesignerWindow window = (CameraDesignerWindow)GetWindow(typeof(CameraDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.maxSize = new Vector2(600, 300);
        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public void InitTextures()
    {
        HeaderSectionTexture = new Texture2D(1, 1);
        HeaderSectionTexture.SetPixel(0, 0, HeaderSectionColor);
        HeaderSectionTexture.Apply();

        CameraFPSSectionTexture = new Texture2D(1, 1);
        CameraFPSSectionTexture.SetPixel(0, 0, CameraFPSSectionColor);
        CameraFPSSectionTexture.Apply();
    }

    public static void InitData()
    {
        m_CameraFPSData = (CameraFPSData)ScriptableObject.CreateInstance(typeof(CameraFPSData));
    }

    #region PRIVATE METHODS

    private void OnGUI()
    {
        DrawLayout();
        DrawHeader();
        DrawFPSSettings();
    }

    private void DrawLayout()
    {
        HeaderSection.x = 0;
        HeaderSection.y = 0;
        HeaderSection.width = Screen.width;
        HeaderSection.height = 80;

        CameraFPSSection.x = 0;
        CameraFPSSection.y = 80;
        CameraFPSSection.width = Screen.width;
        CameraFPSSection.height = Screen.height;

        GUI.DrawTexture(HeaderSection, HeaderSectionTexture);
        GUI.DrawTexture(CameraFPSSection, CameraFPSSectionTexture);
    }

    private void DrawHeader()
    {
        GUILayout.BeginArea(HeaderSection);

        GUILayout.Label("Camera Designer");

        GUILayout.EndArea();
    }

    private void DrawFPSSettings()
    {
        GUILayout.BeginArea(CameraFPSSection);

        GUILayout.Label("FPS");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        m_CameraFPSData.Type = (CameraType)EditorGUILayout.EnumPopup(m_CameraFPSData.Type);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Create", GUILayout.Height(40)))
        {
            GeneralCameraSettings.OpenWindow(GeneralCameraSettings.SettingsType.FPS);
        }

        GUILayout.EndArea();
    }

    #endregion
}

public class GeneralCameraSettings : EditorWindow
{
    public enum SettingsType
    {
        FPS, 
        TPS,
        RTS
    }

    static SettingsType m_CameraSettings;
    static GeneralCameraSettings m_CameraWindow;

    public static void OpenWindow(SettingsType _Settings)
    {
        m_CameraSettings = _Settings;
        m_CameraWindow = (GeneralCameraSettings)GetWindow(typeof(GeneralCameraSettings));
        m_CameraWindow.minSize = new Vector2(250, 250);
        m_CameraWindow.Show();
    }

    #region PRIVATE METHODS

    private void OnGUI()
    {
        switch(m_CameraSettings)
        {
            case SettingsType.FPS:
                DrawSettings((CameraData)CameraDesignerWindow.CameraFPSInfo);
                break;
        }
    }

    private void DrawSettings(CameraData _CameraData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Target");
        _CameraData.Target = (GameObject)EditorGUILayout.ObjectField(_CameraData.Target, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
    }

    #endregion
}