using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OBSOLETE
/// </summary>

public class FirstPersonCamera : MonoBehaviour
{
    #region ATTRIBUTES

    private Camera m_camera = null;
    [SerializeField] private Transform m_target = null;
    private Vector2 m_movementSpeed = new Vector2();

    private float m_offsetPlayerPivot = 0;
    private float m_distance = 5f;
    private float m_mouseX = 0f;
    private float m_mouseY = 0f;
    private float m_forward = -1f;

    #endregion

    #region PROPERTIES

    [Header("Properties")]
    [SerializeField] private float m_smoothCameraRotation = 12f;
    [SerializeField] private float m_rightOffset = 0f;
    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_height = 1.4f;
    [SerializeField] private float m_smoothFollow = 10f;
    [SerializeField] private float m_mouseSensitivityX = 3f;
    [SerializeField] private float m_mouseSensitivityY = 3f;
    [SerializeField] private float m_minX = 0f;
    [SerializeField] private float m_maxX = 0f;
    [SerializeField] private float m_minY = 0f;
    [SerializeField] private float m_maxY = 0f;

    [SerializeField] private FirstPersonCharacter m_firstPersonCharacter = null;

    private float m_xAxisClamp = 0f;

    private static ThirdPersonCamera _instance;

    public static ThirdPersonCamera Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ThirdPersonCamera>();
            }
            return _instance;
        }
    }

    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region PUBLIC METHODS

    public void Init()
    {
        if (m_target == null)
        {
            return;
        }

        m_camera = GetComponent<Camera>();

        m_mouseX = m_target.eulerAngles.x;
        m_mouseY = m_target.eulerAngles.y;
    }

    public void RotateCamera(float _x, float _y)
    {
        m_mouseX += _x * m_mouseSensitivityX;
        m_mouseY -= _y * m_mouseSensitivityY;

        m_movementSpeed.x = _x;
        m_movementSpeed.y = -_y;

        m_xAxisClamp += m_mouseY;

        if (m_xAxisClamp > m_minY)
        {
            m_xAxisClamp = m_minY;
            m_mouseY = 0.0f;
        }
        else if (m_xAxisClamp < m_maxY)
        {
            m_xAxisClamp = m_maxY;
            m_mouseY = 0.0f;
        }

        m_mouseX = m_target.root.localEulerAngles.x;
        m_mouseY = m_target.root.localEulerAngles.y;
    }

    #endregion
}
