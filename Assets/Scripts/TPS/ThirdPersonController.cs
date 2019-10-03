using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
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

    protected ThirdPersonCharacter m_character;
    protected ThirdPersonCamera m_tpsCamera;
    protected CameraTest m_cameraTest;
    [SerializeField] private float m_mouthSpeed = 10f;

    private bool m_isTps = true;

    #endregion

    #region MONOBEHAVIOUR METHODS

    protected virtual void Awake()
    {
        CharacterInit();
    }

    protected virtual void Start()
    {
    }

    protected virtual void LateUpdate()
    {
        if (m_character == null)
        {
            return;
        }

        InputHandle();
    }

    #endregion

    #region PROTECTED METHODS

    protected virtual void CharacterInit()
    {
        m_character = GetComponent<ThirdPersonCharacter>();

        m_tpsCamera = FindObjectOfType<ThirdPersonCamera>();

        m_cameraTest = FindObjectOfType<CameraTest>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void InputHandle()
    {
        //CameraInput();
        ChangePOV();

        if (!m_character.lockMovement)
        {
            MoveCharacter();
            SprintInput();
            JumpInput();
            InteractInput();
        }
        PauseInput();
    }

    #region Character Methods

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
            m_character.Pause();
        }
    }
    #endregion

    #region Camera Methods

    protected virtual void CameraInput()
    {
        if (m_tpsCamera == null)
            return;
        m_tpsCamera.TurnAroundY(Input.GetAxis("Mouse X"));
        m_tpsCamera.TurnAroundX(-Input.GetAxis("Mouse Y"));

        RotateWithCamera();
    }

    protected virtual void ChangePOV()
    {
        m_cameraTest.RaycastTest();
        if (m_cameraTest != null && m_isTps)
        {
            m_cameraTest.TurnAroundY((Input.GetAxis("Mouse X") * m_mouthSpeed));
        }

        //Zoom in
        if (Input.mouseScrollDelta.y >= 0 && m_isTps)
        {
            //m_camera.ChangeCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_cameraTest.TranslateCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_cameraTest.SetFpsPosition();
            
        }

        //Zoom Out
        if (Input.mouseScrollDelta.y <= 0 && !m_isTps)
        {
            //m_camera.ChangeCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_cameraTest.TranslateCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_cameraTest.SetTpsPosition();
            
        }
    }

    protected virtual void RotateWithCamera()
    {
        m_tpsCamera.transform.parent = null;
        float angle = Vector3.SignedAngle(m_character.transform.forward, m_tpsCamera.transform.forward, Vector3.up);
        Quaternion finalRotation = m_character.transform.rotation * Quaternion.Euler(0, angle, 0);
        //m_player.transform.Rotate(Vector3.up, angle);
        m_character.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, finalRotation, 5 * Time.deltaTime);


        m_tpsCamera.transform.parent = m_character.transform;
    }

    #endregion

    #endregion


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

}
