using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraData : ScriptableObject
{
    public GameObject Target;
    public float m_DistanceToTarget;
    public float m_SensitivityX;
    public float m_SensitivityY;
    public float m_ClampX;
    public float m_ClampY;
    public float m_MinX;
    public float m_MaxX;
    public bool m_IsCursorVisible;
    public CursorLockMode m_LockMode;
    public bool m_HasAimPoint;
    public Image m_AimPoint;
    //Controller Mouse X/Y 
}
