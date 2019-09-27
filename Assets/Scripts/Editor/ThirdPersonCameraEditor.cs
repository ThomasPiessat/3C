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

}
