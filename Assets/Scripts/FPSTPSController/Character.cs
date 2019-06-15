﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Layer")]
    public LayerMask m_groundLayer = 1 << 0;
    [SerializeField] protected float m_groundMinDistance = 0.2f;
    [SerializeField] protected float m_groundMaxDistance = 0.5f;

    public float m_colliderHeight;
    public RaycastHit m_groundHit;

    [HideInInspector]
    public Vector2 m_input;
    #region ACTIONS

    private bool m_isGrounded = false;
    private bool m_isSprinting = false;
    private bool m_isJumping = false;

    #endregion

    #region COMPONENTS               

    private Rigidbody m_rigidbody;
    private CapsuleCollider m_capsuleCollider;
    private SphereCollider m_playerFeet;
    [HideInInspector] public PhysicMaterial m_maxFrictionPhysics, m_frictionPhysics, m_slippyPhysics;

    #endregion

    #region VARIABLES

    #region MovementSpeed
    [Header("MovementSpeed")]
    [SerializeField] private float m_speed = 0f;
    [SerializeField] private float m_walkSpeed = 5f;
    [SerializeField] private float m_sprintValue = 8f;
    [HideInInspector] public float m_direction = 0f;
    [HideInInspector] public float m_verticalVelocity = 0f;
    [HideInInspector] public float m_velocity = 0f;
    
    #endregion

    #region Jump
    [Header("Jump")]
    [SerializeField] private float m_jumpTimer = 0.3f;
    private float m_jumpCounter = 0f;
    [SerializeField] private float m_jumpHeight = 12f;
    #endregion

    protected float m_groundDistance;

    public bool m_lockMovement = false;
    #endregion

    public Transform cameraMax;
    public Transform cameraMin;

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
        m_capsuleCollider = GetComponent<CapsuleCollider>();
        m_playerFeet = GetComponent<SphereCollider>();
    }

    public void MoveFront()
    {
        ChangeSpeedValue();
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

    #region CheckGroundMethods

    //private void CheckGround()
    //{
    //    CheckGroundDistance();
    //    if (m_isGrounded && m_input == Vector2.zero)
    //    {
    //        m_capsuleCollider.material = m_maxFrictionPhysics;
    //    }
    //    else if (m_isGrounded && m_input != Vector2.zero)
    //    {
    //        m_capsuleCollider.material = m_frictionPhysics;
    //    }
    //    else
    //    {
    //        m_capsuleCollider.material = m_slippyPhysics;
    //    }

    //    var magVel = (float)System.Math.Round(new Vector3(m_rigidbody.velocity.x, 0, m_rigidbody.velocity.z).magnitude, 2);
    //    magVel = Mathf.Clamp(magVel, 0, 1);

    //    var groundCheckDistance = m_groundMinDistance;
    //    if (magVel > 0.25f)
    //    {
    //        groundCheckDistance = m_groundMaxDistance;
    //    }

    //    if (m_groundDistance <= 0.05f)
    //    {
    //        m_isGrounded = true;
    //    }
    //    else
    //    {
    //        if (m_groundDistance >= groundCheckDistance)
    //        {
    //            m_isGrounded = false;
    //            m_verticalVelocity = m_rigidbody.velocity.y;
    //            if (!m_isJumping)
    //            {
    //                m_rigidbody.AddForce(transform.up * Physics.gravity.y * Time.deltaTime, ForceMode.VelocityChange);
    //            }
    //        }
    //        else if (!m_isJumping)
    //        {
    //            m_rigidbody.AddForce(transform.up * (Physics.gravity.y * 2 * Time.deltaTime), ForceMode.VelocityChange);
    //        }
    //    }
    //}

    //private void CheckGroundDistance()
    //{
    //    if (m_capsuleCollider != null)
    //    {
    //        float radius = m_capsuleCollider.radius * 0.9f;
    //        var dist = 10f;
    //        Vector3 pos = transform.position + Vector3.up * (m_capsuleCollider.radius);
    //        Ray ray1 = new Ray(transform.position + new Vector3(0, m_colliderHeight / 2, 0), Vector3.down);
    //        Ray ray2 = new Ray(pos, -Vector3.up);
    //        if (Physics.Raycast(ray1, out m_groundHit, m_colliderHeight / 2 + 2f, m_groundLayer))
    //            dist = transform.position.y - m_groundHit.point.y;
    //        if (Physics.SphereCast(ray2, radius, out m_groundHit, m_capsuleCollider.radius + 2f, m_groundLayer))
    //        {
    //            if (dist > (m_groundHit.distance - m_capsuleCollider.radius * 0.1f))
    //                dist = (m_groundHit.distance - m_capsuleCollider.radius * 0.1f);
    //        }
    //        m_groundDistance = (float)System.Math.Round(dist, 2);
    //    }

    //}

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(m_playerFeet.bounds.center, new Vector3(m_playerFeet.bounds.center.x, m_playerFeet.bounds.min.y, m_playerFeet.bounds.center.z), m_playerFeet.radius * .9f, m_groundLayer);
    }

    #endregion

    #region JumpMethods

    public void Jump()
    {
        if (IsGrounded())
            m_rigidbody.AddForce(Vector3.up * m_jumpHeight, ForceMode.Impulse);
    }

    #endregion

    private void ChangeSpeedValue()
    {
        if (m_isSprinting)
        {
            m_speed = m_sprintValue;
        }
        else
        {
            m_speed = m_walkSpeed;
        }
    }

    public void Sprint(bool value)
    {
        m_isSprinting = value;
    }

    public void Pause()
    {
        GameMediator.Instance.PauseUI.ToggleMenuPause();
    }
    #endregion
}