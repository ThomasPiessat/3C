using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    #region ATTRIBUTES

    protected Character m_character;
    protected FTPSCamera m_camera;

    #endregion

    #region PROPERTIES

    [Header("Movement Inputs")]
    [SerializeField] private string m_horizontalInput = "Horizontal";
    [SerializeField] private string m_verticalInput = "Vertical";
    [SerializeField] private KeyCode m_sprintInput = KeyCode.LeftShift;
    public List<KeyCode> m_controlKey = new List<KeyCode>();
    public DefautInputStruct m_struct;
    [Header("Action Imputs")]
    [Tooltip("InteractionInput/PickUpInput")]

    [SerializeField] private KeyCode m_item1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode m_item2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode m_leftHandInput = KeyCode.Mouse0;
    [SerializeField] private KeyCode m_rightHandInput = KeyCode.Mouse1;
    [Header("UI Inputs")]
    [SerializeField] private KeyCode m_pauseInput = KeyCode.Escape;
    [SerializeField] private KeyCode m_inventoryInput = KeyCode.I;

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

    #region MONOBEHAVIOUR METHODS

    protected virtual void Start()
    {
        CharacterInit();
    }

    protected virtual void Update()
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

    protected virtual void FixedUpdate()
    {

    }

    #endregion

    #region PROTECTED METHODS

    protected virtual void CharacterInit()
    {
        m_character = GetComponent<Character>();
        m_camera = FindObjectOfType<FTPSCamera>();

        if (m_character != null)
        {
            m_character.Init();
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void InputHandle()
    {
        ChangeCamera(); 

        if (m_camera.m_isFpsCamera)
        {
            m_camera.CameraFPS(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        }

        else if (!m_camera.m_isFpsCamera)
        {
            CameraInput();
        }

        if (!m_character.m_lockMovement)
        {
            MoveCharacter();
            SprintInput();
            JumpInput();

        }
        PickupInput();
        DropInput();
        SelectWeapon();

        LeftHandInput();
        RightHandInput();

        PauseInput();
        InventoryInput();
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
        if (Input.GetKeyDown(m_controlKey[4]))
            m_character.Jump();
    }

    protected virtual void PickupInput()
    {
        if (Input.GetKeyDown(m_controlKey[6]))
        {
            m_character.PickUp();
        }
    }

    protected virtual void DropInput()
    {
        if (Input.GetKeyDown(m_controlKey[7]))
        {
            m_character.Drop();
        }
    }

    protected virtual void SelectWeapon()
    {
        if (Input.GetKeyDown(m_item1))
        {
            m_character.Select(0);
        }

        if (Input.GetKeyDown(m_item2))
        {
            m_character.Select(1);
        }
    }

    protected virtual void LeftHandInput()
    {
        if (Input.GetKeyDown(m_leftHandInput))
        {
            //m_character.Attack(0);
        }
    }

    protected virtual void RightHandInput()
    {
        if(Input.GetKeyDown(m_rightHandInput))
        {
            //m_character.Attack(1);
        }
    }

    #region UI Methods

    protected virtual void PauseInput()
    {
        if (Input.GetKeyDown(m_pauseInput))
        {
            m_character.Pause();
        }
    }

    protected virtual void InventoryInput()
    {
        if (Input.GetKeyDown(m_controlKey[8]))
        {
            m_character.Inventory();
        }
    }

    #endregion

    #endregion

    #region Camera Methods

    protected virtual void CameraInput()
    {
        m_camera.TurnAroundY(Input.GetAxis("Mouse X"));
        m_camera.TurnAroundX(-Input.GetAxis("Mouse Y"));
        //m_camera.RotateWithCamera();
    }

    protected virtual void ChangePOV()
    {
        //Zoom in
        if (Input.mouseScrollDelta.y > 0)
        {
            //m_camera.ChangeCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_camera.TranslateCamera(Input.GetAxis("Mouse ScrollWheel"));
        }

        //Zoom Out
        if (Input.mouseScrollDelta.y < 0)
        {
            //m_camera.ChangeCamera(Input.GetAxis("Mouse ScrollWheel"));
            m_camera.TranslateCamera(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    protected virtual void ChangeCamera()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            m_camera.SetFPSCameraPos();
            m_camera.m_isFpsCamera = true;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            m_camera.SetTPSCameraPos();
            m_camera.m_isFpsCamera = false;
        }
    }

    #endregion

    #endregion
}
