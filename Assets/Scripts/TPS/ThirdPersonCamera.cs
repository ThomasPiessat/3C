using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private ThirdPersonCharacter m_thirdPersonCharacter = null;

    #endregion

    #region PROPERTIES

    [SerializeField] private float m_smoothCameraRotation = 12f;
    [SerializeField] private float m_rightOffset = 0f;
    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_xClampValue = 0;
    [SerializeField] private float m_mouseSensitivity = 3f;

    private static ThirdPersonCamera _instance;

    public static ThirdPersonCamera Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ThirdPersonCamera>();
            }
            return _instance;
        }
    }

    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = (transform.position - m_thirdPersonCharacter.transform.position);
        ReturnToInitialOffset(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_thirdPersonCharacter == null)
        {
            return;
        }
        DetectWallCollisions();
    }


    #endregion

    #region PUBLIC METHODS

    public bool CheckClampX(float _mouseSpeedValue)
    {
        float distance = transform.position.y - m_thirdPersonCharacter.transform.position.y;
        if (_mouseSpeedValue < 0)
        {
            if (distance >= -m_xClampValue)
            {
                return true;
            }
        }
        else
        {
            if (distance <= m_xClampValue)
            {
                return true;
            }
        }
        return false;
    }
    public void TurnAroundY(float _mouseSpeedValue)
    {
        transform.RotateAround(m_thirdPersonCharacter.transform.position, Vector3.up, m_mouseSensitivity * _mouseSpeedValue * Time.deltaTime);
    }

    public void TurnAroundX(float _mouseSpeedValue)
    {
        if (CheckClampX(_mouseSpeedValue))
        {
            transform.RotateAround(m_thirdPersonCharacter.transform.position, transform.right, m_mouseSensitivity * _mouseSpeedValue * Time.deltaTime);
        }
    }

    private void DetectWallCollisions()
    {
        Vector3 direction = (transform.position - m_thirdPersonCharacter.transform.position);

        RaycastHit[] hit = Physics.RaycastAll(m_thirdPersonCharacter.transform.position, direction.normalized, direction.magnitude);
        for (int i = 0; i < hit.Length; i++)
        {
            if (!hit[i].collider.CompareTag("Player"))
            {
                transform.position = Vector3.Lerp(transform.position, hit[i].point, 10 * Time.deltaTime);
                return;
            }
        }
        if (direction.magnitude < m_defaultDistanceToPlayer)
        {
            ReturnToInitialOffset(direction);
        }

    }
    private void ReturnToInitialOffset(Vector3 _direction)
    {
        transform.position += _direction.normalized * m_defaultDistanceToPlayer * Time.deltaTime;
    }

    #endregion

}
