using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour
{
    private static ThirdPersonCamera _instance;

    public static ThirdPersonCamera Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectType<ThirdPersonCamera>();
            }

            return _instance;
        }
    }

    #region ATTRIBUTES

    private Camera m_camera = null;
    private Transform m_target = null;

    private float m_distance = 5f;
    private float m_mouseX = 0f;
    private float m_mouseY = 0f;

    #endregion

    #region PROPERTIES

    [SerializeField] private Transform m_target = null;

    [SerializeField] private float m_smoothCameraRotation = 12f;

    [SerializeField] private float m_rightOffset = 0f;
    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_height = 1.4f;
    [SerializeField] private float m_smoothFollow = 10f;
    [SerializeField] private float m_mouseSensitivityX = 3f;
    [SerializeField] private float m_mouseSensitivityY = 3f;
    #endregion

    #region MONOBEHAVIOUR METHODS
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (m_target == null)
        {
            return;
        }

        CameraMovement();
    }


    #endregion

    private void Init()
    {
        if (m_target == null)
        {
            return;
        }

        m_camera = GetComponent<Camera>();

        m_mouseX = m_target.eulerAngles.x;
        m_mouseY = m_target.eulerAngles.y;
    }

    private void CameraMovement()
    {
        
    }
}
