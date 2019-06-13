﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour
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
    private GameObject m_interactable = null;

    #endregion

    #region PROPERTIES

    [SerializeField] private float m_smoothCameraRotation = 12f;
    [SerializeField] private float m_rightOffset = 0f;
    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_height = 1.4f;
    [SerializeField] private float m_smoothFollow = 10f;
    [SerializeField] private float m_mouseSensitivityX = 3f;
    [SerializeField] private float m_mouseSensitivityY = 3f;

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

        m_mouseX = m_target.root.localEulerAngles.x;
        m_mouseY = m_target.root.localEulerAngles.y;
    }

    public void CameraMovement()
    {
        m_distance = Mathf.Lerp(m_distance, m_defaultDistanceToPlayer, m_smoothFollow * Time.deltaTime);
        Vector3 camDir = (m_forward * m_target.forward);

        camDir = camDir.normalized;

        Vector3 targetPos = new Vector3(m_target.transform.position.x, m_target.transform.position.y + m_offsetPlayerPivot, +m_target.transform.position.z);
    }

    public void Interact()
    {
        //m_interactable?.Interaction();
    }

    #endregion

}
