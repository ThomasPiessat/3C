using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonImput : MonoBehaviour
{
    #region VARIABLES

    [Header("Default Inputs")]
    public string horizontalInput = "Horizontal";
    public string verticallInput = "Vertical";
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode strafeInput = KeyCode.Tab;
    public KeyCode sprintInput = KeyCode.LeftShift;
    public KeyCode interactInput = KeyCode.E;

    [Header("Camera Settings")]
    public string rotateCameraXInput = "Mouse X";
    public string rotateCameraYInput = "Mouse Y";

    protected ThirdPersonController m_cc;
    protected ThirdPersonCamera m_tpsCamera;

    #endregion

    protected virtual void Start()
    {
        CharacterInit();
    }

    protected virtual void CharacterInit()
    {
        m_cc = GetComponent<ThirdPersonController>();
        if (m_cc != null)
            m_cc.Init();

        m_tpsCamera = FindObjectOfType<ThirdPersonCamera>();
        //if (m_tpsCamera) m_tpsCamera.SetMainTarget(this.transform);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void LateUpdate()
    {
        if (m_cc == null) return;             // returns if didn't find the controller		    
        InputHandle();                      // update input methods
        UpdateCameraStates();               // update camera states
    }

    protected virtual void FixedUpdate()
    {
        //m_cc.AirControl();
        CameraInput();
    }


    protected virtual void InputHandle()
    {
        CameraInput();

        if (!m_cc.lockMovement)
        {
            MoveCharacter();
            SprintInput();
            JumpInput();
            InteractInput();
        }
    }

    protected virtual void MoveCharacter()
    {
        m_cc.m_input.x = Input.GetAxis(horizontalInput);
        m_cc.m_input.y = Input.GetAxis(verticallInput);
    }

    protected virtual void SprintInput()
    {
        if (Input.GetKeyDown(sprintInput))
            m_cc.Sprint(true);
        else if (Input.GetKeyUp(sprintInput))
            m_cc.Sprint(false);
    }

    protected virtual void JumpInput()
    {
        if (Input.GetKeyDown(jumpInput))
            m_cc.Jump();
    }

    protected virtual void InteractInput()
    {
        if (Input.GetKeyDown(interactInput))
        {
            //m_tpsCamera.Interact();
        }
    }

    #region Camera Methods

    protected virtual void CameraInput()
    {
        if (m_tpsCamera == null)
            return;
        var Y = Input.GetAxis(rotateCameraYInput);
        var X = Input.GetAxis(rotateCameraXInput);

        //m_tpsCamera.RotateCamera(X, Y);

        // tranform Character direction from camera if not KeepDirection
        //if (!keepDirection)
        //    m_cc.UpdateTargetDirection(m_tpsCamera != null ? m_tpsCamera.transform : null);
        // rotate the character with the camera while strafing        
        RotateWithCamera(m_tpsCamera != null ? m_tpsCamera.transform : null);
    }

    protected virtual void UpdateCameraStates()
    {
        // CAMERA STATE - you can change the CameraState here, the bool means if you want lerp of not, make sure to use the same CameraState String that you named on TPCameraListData
        if (m_tpsCamera == null)
        {
            m_tpsCamera = FindObjectOfType<ThirdPersonCamera>();
            if (m_tpsCamera == null)
                return;
            if (m_tpsCamera)
            {
                //m_tpsCamera.SetMainTarget(this.transform);
                //m_tpsCamera.Init();
            }
        }
    }

    protected virtual void RotateWithCamera(Transform cameraTransform)
    {
        //if (m_cc.lockMovement)
        //{
        //    m_cc.RotateWithAnotherTransform(cameraTransform);
        //}
    }

    #endregion


}
