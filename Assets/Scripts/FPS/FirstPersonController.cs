using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// OBSOLETE
/// </summary>

public class FirstPersonController : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("Default Inputs")]
    [SerializeField] private string m_horizontalInput = "Horizontal";
    [SerializeField] private string m_verticalInput = "Vertical";
    [SerializeField] private KeyCode m_jumpInput = KeyCode.Space;
    [SerializeField] private KeyCode m_sprintInput = KeyCode.LeftShift;
    [SerializeField] private KeyCode m_pauseInput = KeyCode.Escape;
    public List<KeyCode> m_controlKey = new List<KeyCode>();
    public DefautInputStruct m_struct;

    [Header("Camera Settings")]
    [SerializeField] private string m_rotateCameraXInput = "Mouse X";
    [SerializeField] private string m_rotateCameraYInput = "Mouse Y";

    protected FirstPersonCharacter m_character;
    protected FirstPersonCamera m_fpsCamera;

    [Serializable]
    public struct DefautInputStruct
    {
        public KeyCode m_forward;
        public KeyCode m_back;
        public KeyCode m_left;
        public KeyCode m_right;
        public KeyCode m_jump;
        public KeyCode m_sprint;
        public KeyCode m_pickUP;
        public KeyCode m_drop;
        public KeyCode m_inventory;
    }

    #endregion

    protected virtual void Start()
    {
        CharacterInit();
    }

    protected virtual void CharacterInit()
    {
        m_character = GetComponent<FirstPersonCharacter>();

        m_fpsCamera = FindObjectOfType<FirstPersonCamera>();
        //if (m_fpsCamera) m_fpsCamera.SetMainTarget(this.transform);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void LateUpdate()
    {
        if (m_character == null)
        {
            return;
        }

        InputHandle();
        UpdateCameraStates();
    }

    protected virtual void FixedUpdate()
    {
        //m_cc.AirControl();
        CameraInput();
    }


    protected virtual void InputHandle()
    {
        CameraInput();

        if (!m_character.lockMovement)
        {
            MoveCharacter();
            SprintInput();
            JumpInput();
            InteractInput();
        }
    }

    protected virtual void MoveCharacter()
    {
        m_character.m_input.x = Input.GetAxis(m_horizontalInput);
        m_character.m_input.y = Input.GetAxis(m_verticalInput);

        if (Input.GetKey(m_controlKey[0]))
        {
            m_character.MoveFront();
        }
        if (Input.GetKey(m_controlKey[1]))
        {
            m_character.MoveBack();
        }
        if (Input.GetKey(m_controlKey[2]))
        {
            m_character.MoveLeft();
        }
        if (Input.GetKey(m_controlKey[3]))
        {
            m_character.MoveRight();
        }

    }

    protected virtual void SprintInput()
    {
        if (Input.GetKeyDown(m_sprintInput))
        {
            m_character.Sprint(true);
        }
        else if (Input.GetKeyUp(m_sprintInput))
        {
            m_character.Sprint(false);
        }
    }

    protected virtual void JumpInput()
    {
        if (Input.GetKeyDown(m_jumpInput))
            m_character.Jump();
    }

    protected virtual void InteractInput()
    {
        if (Input.GetKeyDown(m_controlKey[5]))
        {
            //m_fpsCamera.Interact();
        }
    }

    protected virtual void PauseInput()
    {
        if (Input.GetKeyDown(m_pauseInput))
        {

        }
    }

    #region Camera Methods

    protected virtual void CameraInput()
    {
        if (m_fpsCamera == null)
            return;
        var Y = Input.GetAxis(m_rotateCameraYInput);
        var X = Input.GetAxis(m_rotateCameraXInput);

        m_fpsCamera.RotateCamera(X, Y);

        // tranform Character direction from camera if not KeepDirection
        //if (!keepDirection)
        //    m_cc.UpdateTargetDirection(m_fpsCamera != null ? m_fpsCamera.transform : null);
        // rotate the character with the camera while strafing        
        RotateWithCamera(m_fpsCamera != null ? m_fpsCamera.transform : null);
    }

    protected virtual void UpdateCameraStates()
    {
        // CAMERA STATE - you can change the CameraState here, the bool means if you want lerp of not, make sure to use the same CameraState String that you named on TPCameraListData
        if (m_fpsCamera == null)
        {
            m_fpsCamera = FindObjectOfType<FirstPersonCamera>();
            if (m_fpsCamera == null)
                return;
            if (m_fpsCamera)
            {
                //m_fpsCamera.SetMainTarget(this.transform);
                m_fpsCamera.Init();
            }
        }
    }

    protected virtual void RotateWithCamera(Transform cameraTransform)
    {
        //if (m_cc.m_lockMovement)
        //{
        //    m_cc.RotateWithAnotherTransform(cameraTransform);
        //}
    }

    #endregion
}

