using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    [HideInInspector]
    public Vector2 m_input;

    #region ACTIONS
    // movement bools
    [HideInInspector]
    public bool
        m_isGrounded,
        m_isSprinting;

    // action bools
    [HideInInspector]
    public bool
        m_isJumping;
    #endregion

    #region COMPONENTS               
    
    [HideInInspector]
    public Rigidbody m_rigidbody;

    #endregion

    #region VARIABLES

    [HideInInspector]
    public float m_speed, m_direction, m_verticalVelocity;    // general variables to the locomotion
    [HideInInspector]
    public float m_velocity;

    public bool lockMovement;
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
        // conditions to do this action
        bool jumpConditions = m_isGrounded && !m_isJumping;
        // return if jumpCondigions is false
        if (!jumpConditions) return;
        // trigger jump behaviour
        //jumpCounter = jumpTimer;
        m_isJumping = true;
    }

}
