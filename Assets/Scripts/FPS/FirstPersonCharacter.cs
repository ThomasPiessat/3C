using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// OBSOLETE
/// </summary>
public class FirstPersonCharacter : MonoBehaviour
{
    [HideInInspector]
    public Vector2 m_input;

    #region ACTIONS

    [SerializeField] private bool m_isGrounded = false;
    [SerializeField] private bool m_isSprinting = false;
    [SerializeField] private bool m_isJumping = false;

    #endregion

    #region COMPONENTS               

    [HideInInspector]
    public Rigidbody m_rigidbody;

    #endregion

    #region VARIABLES

    [SerializeField] private float m_speed = 5f;
    [HideInInspector]
    public float m_direction = 0f;
    [HideInInspector]
    public float m_verticalVelocity = 0f;
    [HideInInspector]
    public float m_velocity = 0f;

    [SerializeField] private float m_jumpTimer = 0.3f;
    [SerializeField] private float m_jumpCounter = 0f;

    public bool lockMovement = false;
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

    #region CONTROLLER

    public void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    public void MoveFront()
    {
        transform.position += transform.forward * m_speed * Time.deltaTime;
    }
    public void MoveBack()
    {
        transform.position += -transform.forward * m_speed * Time.deltaTime;
    }
    public void MoveRight()
    {
        transform.position += transform.right * m_speed * Time.deltaTime;
    }
    public void MoveLeft()
    {
        transform.position += -transform.right * m_speed * Time.deltaTime;
    }

    public virtual void Sprint(bool value)
    {
        m_isSprinting = value;
    }

    public virtual void Jump()
    {
        bool jumpConditions = m_isGrounded && !m_isJumping;

        if (!jumpConditions)
            return;
        m_jumpCounter = m_jumpTimer;
        m_isJumping = true;
    }

    public void Pause()
    {
        GameMediator.Instance.PauseUI.ToggleMenuPause();
    }
    #endregion
}
