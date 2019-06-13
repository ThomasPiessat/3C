using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [HideInInspector]
    public Vector2 m_input;

    #region ACTIONS
    [HideInInspector]
    public bool m_isGrounded = false;
    [HideInInspector]
    public bool m_isSprinting = false;
    [HideInInspector]
    public bool m_isJumping = false;
    #endregion

    #region COMPONENTS               

    [HideInInspector]
    public Rigidbody m_rigidbody;

    #endregion

    #region VARIABLES

    [HideInInspector]
    public float m_speed = 0f;
    [HideInInspector]
    public float m_direction = 0f;
    [HideInInspector]
    public float  m_verticalVelocity = 0f;
    [HideInInspector]
    public float m_velocity = 0f;

    [HideInInspector]
    public float m_jumpTimer = 0f;
    [HideInInspector]
    public float m_jumpCounter = 0f;

    public bool lockMovement = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {

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

}
