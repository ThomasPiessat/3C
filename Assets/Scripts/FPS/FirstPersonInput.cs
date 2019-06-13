using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonInput : MonoBehaviour
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

    //protected FirstPersonController m_fpsController;
    //protected FirstPersonCamera m_fpsCamera;
    //protected FirstPersonCharacter m_fpsCharacter;

    //#endregion

    //#region PROPERTIES



    //#endregion

    //#region MONOBEHAVIOUR METHODS

    //Start is called before the first frame update
    //void Start()
    //{
    //    CharacterInit();
    //}

    //Update is called once per frame
    //void Update()
    //{

    //}

    //protected virtual void LateUpdate()
    //{
    //    if (m_fpsController == null)
    //    {
    //        return;
    //    }

    //    InputHandle();
    //}

    //protected virtual void FixedUpdate()
    //{
    //    m_cc.AirControl();
    //    CameraInput();
    //}

    //#endregion

    //#region PROTECTED METHODS

    //protected virtual void CharacterInit()
    //{
    //    m_fpsController = GetComponent<FirstPersonController>();
    //    if (m_fpsController != null)
    //    {
    //        m_fpsController.Init();
    //    }

    //    m_fpsCamera = FindObjectOfType<FirstPersonCamera>();
    //    if (m_fpsCamera) m_fpsCamera.SetMainTarget(this.transform);

    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //protected virtual void InputHandle()
    //{
    //    CameraInput();

    //    if (!m_fpsController)
    //    {
    //        MoveCharacter();
    //        SprintInput();
    //        JumpInput();
    //    }
    //}

    //#region Movement
    //protected virtual void MoveCharacter()
    //{
    //    if (Input.GetKey(m_fwdInput))
    //    {
    //        m_fpsCharacter.MoveFront();
    //    }
    //    if (Input.GetKey(m_bwdInput))
    //    {
    //        m_fpsCharacter.MoveBack();
    //    }
    //    if (Input.GetKey(m_leftInput))
    //    {
    //        m_fpsCharacter.MoveLeft();
    //    }
    //    if (Input.GetKey(m_rightInput))
    //    {
    //        m_fpsCharacter.MoveRight();
    //    }
    //}

    //protected virtual void SprintInput()
    //{
    //    if (Input.GetKeyDown(m_sprintInput))
    //        m_fpsController.Sprint(true);
    //    else if (Input.GetKeyUp(m_sprintInput))
    //        m_fpsController.Sprint(false);
    //}

    //protected virtual void JumpInput()
    //{
    //    if (Input.GetKeyDown(m_jumpInput))
    //        m_fpsController.Jump();
    //}

    //#endregion

    //#region Camera

    //protected virtual void CameraInput()
    //{
    //    if (m_fpsCamera == null)
    //        return;
    //    var Y = Input.GetAxis(m_rotateCameraYInput);
    //    var X = Input.GetAxis(m_rotateCameraXInput);

    //    m_fpsCamera.RotateCamera(X, Y);
    //}

    //#endregion
    //#endregion
}
