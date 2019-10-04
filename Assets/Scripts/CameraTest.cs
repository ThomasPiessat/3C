using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTest : MonoBehaviour
{
    [SerializeField] private ThirdPersonCharacter m_thirdPersonCharacter = null;
    [SerializeField] private GameObject m_playerHead = null;
    [SerializeField] private GameObject m_tpsCameraPosition = null;

    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_xClampValue = 35f;

    private float m_mouseX = 0f;
    private float m_mouseY = 0f;

    private float m_xAxisClamp = 0f;
    private Vector2 m_movementSpeed = new Vector2();

    [SerializeField] private float m_mouseSensitivityX = 3f;
    [SerializeField] private float m_mouseSensitivityY = 3f;
    [SerializeField] private float m_minX = 0f;
    [SerializeField] private float m_maxX = 0f;
    [SerializeField] private float m_minY = 0f;
    [SerializeField] private float m_maxY = 0f;

    public bool m_isTps = true;

    private static CameraTest m_instance;

    public static CameraTest Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.FindObjectOfType<CameraTest>();
            }

            return m_instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetDefaultPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetDefaultPosition()
    {
        transform.position = m_tpsCameraPosition.transform.position;
    }

    public void CheckClampX()
    {
        if (transform.rotation.x > m_xClampValue)
        {
            Debug.Log("Clamp");
        }
    }

    public void TurnAroundY(float _mouseSpeedValue)
    {
        transform.RotateAround(m_thirdPersonCharacter.transform.position, Vector3.up, _mouseSpeedValue * Time.deltaTime);
    }

    public void TranslateCamera(float _wheelSpeed)
    {
        transform.Translate(Vector3.forward * _wheelSpeed * 100 * Time.deltaTime);
    }

    public void SetFpsPosition()
    {
        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) < 1.5f)
        {
            transform.position = m_playerHead.transform.position;
            //camera is Fps 
            m_isTps = false;
        }
    }

    public void SetTpsPosition()
    {
        if (Vector3.Distance(transform.position, m_tpsCameraPosition.transform.position) < 1.5f)
        {
            transform.position = m_tpsCameraPosition.transform.position;
            //camera is tps
            m_isTps = true;
        }
    }

    public void CheckPositionDistance()
    {
        if (Vector3.Distance(transform.position, m_tpsCameraPosition.transform.position) == 0)
        {
            m_isTps = true;
        }
        else if (Vector3.Distance(transform.position, m_playerHead.transform.position) == 0)
        {
            m_isTps = false;
        }
    }

    public void CameraFPS(float _x, float _y)
    {
        m_mouseX += _x * m_mouseSensitivityX;
        m_mouseY -= _y * m_mouseSensitivityY;

        m_movementSpeed.x = _x;
        m_movementSpeed.y = -_y;

        m_xAxisClamp += m_mouseY;

        if (m_xAxisClamp > m_minY)
        {
            m_xAxisClamp = m_minY;
            m_mouseY = 0.0f;
        }
        else if (m_xAxisClamp < m_maxY)
        {
            m_xAxisClamp = m_maxY;
            m_mouseY = 0.0f;
        }

        m_mouseX = m_thirdPersonCharacter.transform.root.localEulerAngles.x;
        m_mouseY = m_thirdPersonCharacter.transform.root.localEulerAngles.y;

    }

    public void RaycastTest()
    {
        Vector3 direction = (transform.position - m_thirdPersonCharacter.transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, m_thirdPersonCharacter.transform.position,
            out hit, 10f))
        {
            Debug.DrawRay(transform.position, m_thirdPersonCharacter.transform.position * hit.distance, Color.blue);
        }
    }
}
