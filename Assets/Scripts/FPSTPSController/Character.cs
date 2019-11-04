using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("Layer")]
    public LayerMask m_groundLayer = 1 << 0;
    [SerializeField] protected float m_groundMinDistance = 0.2f;
    [SerializeField] protected float m_groundMaxDistance = 0.5f;

    public float m_colliderHeight = 0f;
    public RaycastHit m_groundHit;

    [Header("ItemManager")]
    //see in inspector (=> to remove)
    [SerializeField] private List<GameObject> m_listItems = null;
    [SerializeField] public int m_maxItemsToHold = 2;
    //see in inspector (=> to remove)
    [SerializeField] private GameObject m_currentWeapon = null;
    [SerializeField] private Transform m_characterRightHand = null;
    [SerializeField] private Transform m_dropPoint = null;
    [SerializeField] private FTPSCamera m_FTPSCamera = null;
    [SerializeField] private float m_pickUpDistance = 50f;

    [HideInInspector]
    public Vector2 m_input;

    /*DEBUG//TEST*/
    [SerializeField] private Sword m_sword = null;
    [SerializeField] public List<Item> m_items = null;

    #endregion    

    #region ACTIONS

    private bool m_isGrounded = false;
    private bool m_isSprinting = false;
    private bool m_isJumping = false;

    #endregion

    #region COMPONENTS               

    private Rigidbody m_rigidbody;
    private CapsuleCollider m_capsuleCollider;
    private SphereCollider m_playerFeet;
    private Transform m_playerHand;
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

    #region Health

    private float m_maxHealth = 100f;
    private float m_currentHealth = 0f;
    private bool m_isDead = false;

    #endregion

    #endregion

    public Transform cameraMax;
    public Transform cameraMin;

    #region GET/SET

    public float GetCurrentHealth()
    {
        return m_currentHealth;
    }

    public float GetMaxHealth()
    {
        return m_maxHealth;
    }

    public bool GetIsDead()
    {
        return m_isDead;
    }

    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        m_currentHealth = m_maxHealth; 
        m_listItems = new List<GameObject>();
        m_items = new List<Item>();
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
        m_playerHand = GetComponent<Transform>();
    }

    #region MovementMethods

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

    #endregion

    #region PickupMethods

    public void PickUp()
    {
        DetectWeaponMax();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, m_pickUpDistance))
        {
            if (hit.transform.GetComponent<Item>() && m_listItems.Count < m_maxItemsToHold)
            {
                m_listItems.Add(hit.collider.gameObject);
                m_items.Add(hit.transform.GetComponent<Item>());
                hit.collider.gameObject.SetActive(false);

                hit.transform.parent = m_characterRightHand;
                hit.transform.localPosition = Vector3.zero;
                A();
            }
        }        
    }

    public void Drop()
    {
        if (m_currentWeapon != null)
        {
            m_currentWeapon.transform.parent = null;
            m_currentWeapon.transform.position = m_dropPoint.position;

            var weaponID = m_currentWeapon.GetInstanceID();

            for (int i = 0; i < m_listItems.Count; i++)
            {
                if (m_listItems[i].GetInstanceID() == weaponID)
                {
                    m_listItems.RemoveAt(i);
                    B();
                    break;
                }
            }
            m_currentWeapon = null;
        }
    }

    public void Select(int _index)
    {
        if (m_listItems.Count > _index && m_listItems[_index] != null)
        {
            if (m_currentWeapon != null)
            {
                m_currentWeapon.gameObject.SetActive(false);
            }

            m_currentWeapon = m_listItems[_index];
            m_currentWeapon.SetActive(true);
        }
    }

    #endregion

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

    public void Attack(int _index)
    {
        if (m_listItems.Count > _index && m_listItems[_index] != null)
        {
            Debug.Log("attack");
            if (m_currentWeapon != null)
            {
                m_sword.Attack(40);
            }
        }
    }

    #endregion

    #region PUBLIC METHODS

    public void TakeDamage(float _damageTaken)
    {
        m_currentHealth -= _damageTaken;
        if (m_currentHealth <= 0)
        {
            m_isDead = true;
            Die();
        }
    }

    public void Die()
    {
        Destroy(this);
    }

    #endregion

    #region UI METHODS

    private void DetectWeaponMax()
    {
        if (m_listItems.Count == m_maxItemsToHold)
        {
            GameMediator.Instance.UIManager.EnableTooManyItemsUI(true);
        }
        else
        {
            GameMediator.Instance.UIManager.EnableTooManyItemsUI(false);
        }
    }

    private void A()
    {
        GameMediator.Instance.InventoryUI.DisplayOnRightPanel();
    }

    private void B()
    {
        GameMediator.Instance.InventoryUI.DestroyItemButtonInventory();
    }

    public void Pause()
    {
        GameMediator.Instance.PauseUI.ToggleMenuPause();
    }

    public void Inventory()
    {
        GameMediator.Instance.InventoryUI.ToggleInventory();
    }

    #endregion

}
