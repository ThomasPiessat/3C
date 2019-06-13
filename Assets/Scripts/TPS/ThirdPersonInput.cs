using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInput : MonoBehaviour
{
    //#region ATTRIBUTES

    //[Header("Default Inputs")]
    //[SerializeField] private string m_horizontalInput = "Horizontal";
    //[SerializeField] private string m_verticalInput = "Vertical";
    //[SerializeField] private KeyCode m_fwdInput = KeyCode.Z;
    //[SerializeField] private KeyCode m_bwdInput = KeyCode.S;
    //[SerializeField] private KeyCode m_leftInput = KeyCode.Q;
    //[SerializeField] private KeyCode m_rightInput = KeyCode.D;
    //[SerializeField] private KeyCode m_jumpInput = KeyCode.Space;
    //[SerializeField] private KeyCode m_strafeInput = KeyCode.Tab;
    //[SerializeField] private KeyCode m_sprintInput = KeyCode.LeftShift;
    //[SerializeField] private KeyCode m_interactInput = KeyCode.E;
    //[SerializeField] private KeyCode m_pauseInput = KeyCode.Escape;

    //[Header("Camera Settings")]
    //[SerializeField] private string m_rotateCameraXInput = "Mouse X";
    //[SerializeField] private string m_rotateCameraYInput = "Mouse Y";

    //protected ThirdPersonController m_controller;
    //protected ThirdPersonCamera m_fpsCamera;
    //protected ThirdPersonCharacter m_character;

    //#endregion

    //protected virtual void Start()
    //{
    //    CharacterInit();
    //}

    //protected virtual void CharacterInit()
    //{
    //    m_character = GetComponent<ThirdPersonCharacter>();
    //    m_controller = GetComponent<ThirdPersonController>();

    //    if (m_controller != null)
    //    {
    //        m_controller.Init();
    //    }

    //    m_fpsCamera = FindObjectOfType<ThirdPersonCamera>();
    //    //if (m_fpsCamera) m_fpsCamera.SetMainTarget(this.transform);

    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //protected virtual void LateUpdate()
    //{
    //    if (m_controller == null)
    //    {
    //        return;
    //    }

    //    InputHandle();
    //    UpdateCameraStates();
    //}

    //protected virtual void FixedUpdate()
    //{
    //    //m_cc.AirControl();
    //    CameraInput();
    //}


    //protected virtual void InputHandle()
    //{
    //    CameraInput();

    //    if (!m_controller.lockMovement)
    //    {
    //        MoveCharacter();
    //        SprintInput();
    //        JumpInput();
    //        InteractInput();
    //    }
    //}

    //protected virtual void MoveCharacter()
    //{
    //    m_controller.m_input.x = Input.GetAxis(m_horizontalInput);
    //    m_controller.m_input.y = Input.GetAxis(m_verticalInput);

    //    //if (Input.GetKey(m_fwdInput))
    //    //{
    //    //    m_character.MoveFront();
    //    //}
    //    //if (Input.GetKey(m_bwdInput))
    //    //{
    //    //    m_character.MoveBack();
    //    //}
    //    //if (Input.GetKey(m_leftInput))
    //    //{
    //    //    m_character.MoveLeft();
    //    //}
    //    //if (Input.GetKey(m_rightInput))
    //    //{
    //    //    m_character.MoveRight();
    //    //}
    //}

    //protected virtual void SprintInput()
    //{
    //    if (Input.GetKeyDown(m_sprintInput))
    //    {
    //        m_controller.Sprint(true);
    //    }
    //    else if (Input.GetKeyUp(m_sprintInput))
    //    {
    //        m_controller.Sprint(false);
    //    }
    //}

    //protected virtual void JumpInput()
    //{
    //    if (Input.GetKeyDown(m_jumpInput))
    //        m_controller.Jump();
    //}

    //protected virtual void InteractInput()
    //{
    //    if (Input.GetKeyDown(m_interactInput))
    //    {
    //        //m_fpsCamera.Interact();
    //    }
    //}

    //protected virtual void PauseInput()
    //{
    //    if (Input.GetKeyDown(m_pauseInput))
    //    {
            
    //    }
    //}

    //#region Camera Methods

    //protected virtual void CameraInput()
    //{
    //    if (m_fpsCamera == null)
    //        return;
    //    var Y = Input.GetAxis(m_rotateCameraYInput);
    //    var X = Input.GetAxis(m_rotateCameraXInput);

    //    m_fpsCamera.RotateCamera(X, Y);

    //    // tranform Character direction from camera if not KeepDirection
    //    //if (!keepDirection)
    //    //    m_cc.UpdateTargetDirection(m_fpsCamera != null ? m_fpsCamera.transform : null);
    //    // rotate the character with the camera while strafing        
    //    RotateWithCamera(m_fpsCamera != null ? m_fpsCamera.transform : null);
    //}

    //protected virtual void UpdateCameraStates()
    //{
    //    // CAMERA STATE - you can change the CameraState here, the bool means if you want lerp of not, make sure to use the same CameraState String that you named on TPCameraListData
    //    if (m_fpsCamera == null)
    //    {
    //        m_fpsCamera = FindObjectOfType<ThirdPersonCamera>();
    //        if (m_fpsCamera == null)
    //            return;
    //        if (m_fpsCamera)
    //        {
    //            //m_fpsCamera.SetMainTarget(this.transform);
    //            m_fpsCamera.Init();
    //        }
    //    }
    //}

    //protected virtual void RotateWithCamera(Transform cameraTransform)
    //{
    //    //if (m_cc.lockMovement)
    //    //{
    //    //    m_cc.RotateWithAnotherTransform(cameraTransform);
    //    //}
    //}

    //#endregion


}
