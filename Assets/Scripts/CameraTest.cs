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

    [SerializeField] private float m_maxTranslate = 0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) <= 10.1f)
        {
            transform.Translate(Vector3.forward * _wheelSpeed * 100 * Time.deltaTime);
        }
    }

    public void TranslateCameraIn(float _wheelSpeed)
    {
        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) <= 10.1f)
        {
            transform.Translate(Vector3.forward * _wheelSpeed * 100 * Time.deltaTime);
        }
    }

    public void TranslateOutCamera(float _wheelSpeed)
    {

        if (transform.position == m_playerHead.transform.position)
        {
            transform.Translate(Vector3.forward * _wheelSpeed * 100 * Time.deltaTime);

        }        
        
        //Make this test in the controller therewith switch camera
        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) < 1.5f)
        {
            Debug.Log($"Stop");
        }

    }

    public void SetFpsPosition()
    {
        //Make this test in the controller therewith switch camera
        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) < 1.5f)
        {
            transform.position = m_playerHead.transform.position;
        }
    }

    public void SetTpsPosition()
    {
    }

    public bool IsFpsPosition()
    {
        transform.position = m_playerHead.transform.position;
        return true;
    }

    public bool IsTpsPosition()
    {
        transform.position = m_tpsCameraPosition.transform.position;
        return true;
    }

    private void CameraFPS(float _x, float _y)
    {
        //m_mouseX += _x * m_mouseSensitivityX;
        //m_mouseY -= _y * m_mouseSensitivityY;

        //m_movementSpeed.x = _x;
        //m_movementSpeed.y = -_y;

        //m_xAxisClamp += m_mouseY;

        //if (m_xAxisClamp > m_minY)
        //{
        //    m_xAxisClamp = m_minY;
        //    m_mouseY = 0.0f;
        //}
        //else if (m_xAxisClamp < m_maxY)
        //{
        //    m_xAxisClamp = m_maxY;
        //    m_mouseY = 0.0f;
        //}

        //m_mouseX = m_target.root.localEulerAngles.x;
        //m_mouseY = m_target.root.localEulerAngles.y;

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
