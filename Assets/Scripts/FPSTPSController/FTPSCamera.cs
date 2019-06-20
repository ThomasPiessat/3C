using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class FTPSCamera : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private Character m_character = null;

    #endregion

    #region PROPERTIES

    [Header("Camera Properties")]
    [SerializeField] private float m_defaultDistanceToPlayer = 0f;
    [SerializeField] private float m_sensitivityX = 0f;
    [SerializeField] private float m_sensitivityY = 0f;
    [SerializeField] private float m_scrollSpeed = 10f;
    [SerializeField] private float m_minX = 360f;
    [SerializeField] private float m_maxX = 360f;
    [SerializeField] private float m_minY = 90f;
    [SerializeField] private float m_maxY = -90f;
    private float m_mouseX = 0f;
    private float m_mouseY = 0f;

    //FPS Camera
    [SerializeField] private float m_cameraZoomMin = 0f;

    //TPS Camera
    [SerializeField] private float m_cameraZoomMax = 10f;

    [SerializeField] private float m_zoomAmount = 0f;

    [SerializeField] private float m_xAxisClamp = 0f;

    [Header("Camera UI")]
    [SerializeField] private Image m_aimPoint = null;
    [SerializeField] private float m_interactableDistance = 50f;

    public bool m_fpsCamera = true;
    #endregion

    #region MONOBEHAVIOUR METHODS

    private void Start()
    {

    }


    private void Update()
    {
        DetectWallCollisions();
    }

    private void FixedUpdate()
    {
        InteractableUpdate();
    }

    #endregion

    #region PUBLIC METHODS

    public bool CheckClampX(float _mouseValue)
    {
        float distance = transform.position.y - m_character.transform.position.y;

        if (_mouseValue < 0)
        {
            if (distance >= -m_xAxisClamp)
            {
                return true;
            }
        }
        else
        {
            if (distance <= m_xAxisClamp)
            {
                return true;
            }
        }

        return false;
    }

    public void TurnAroundY(float _mouseSpeedValue)
    {
        transform.RotateAround(m_character.transform.position, Vector3.up,
            m_sensitivityY * _mouseSpeedValue * Time.deltaTime);
    }

    public void TurnAroundX(float _mouseSpeedValue)
    {
        if (CheckClampX(_mouseSpeedValue))
        {
            transform.RotateAround(m_character.transform.position, transform.right,
                m_sensitivityX * _mouseSpeedValue * Time.deltaTime);
        }
    }

    public void RotateWithCamera()
    {
        transform.parent = null;
        float angle = Vector3.SignedAngle(m_character.transform.forward, transform.forward, Vector3.up);
        Quaternion finalRotation = m_character.transform.rotation * Quaternion.Euler(0, angle, 0);
        //m_player.transform.Rotate(Vector3.up, angle);
        m_character.transform.rotation = Quaternion.Lerp(m_character.transform.rotation, finalRotation, 5 * Time.deltaTime);


        transform.parent = m_character.transform;
    }

    public bool CheckClampTranslation()
    {
        float distance = transform.position.z - m_character.transform.position.z;
        Debug.Log(distance);
        if (distance >= m_cameraZoomMin)
        {
            return true;
        }

        if (distance <= m_cameraZoomMax)
        {
            return true;
        }

        return false;
    }

    public void TranslateCamera(float _wheelSpeedValue)
    {
        Vector3 dir = m_character.transform.position - transform.position;

        transform.Translate(dir.normalized * _wheelSpeedValue * m_scrollSpeed, Space.World);

    }

    public void Test(float _mouseWheelValue)
    {
        transform.Translate(m_character.cameraMax.position.normalized * _mouseWheelValue * m_scrollSpeed, Space.World);
    }

    public void ChangeCamera(float _mouseWheelValue)
    {
        Vector3 dir = m_character.transform.position - transform.position;
        transform.Translate(dir.normalized * _mouseWheelValue * m_scrollSpeed, Space.World);
        Debug.Log(transform.position.z);
    }

    public bool CameraMax()
    {
        m_fpsCamera = false;
        transform.position = new Vector3(m_character.cameraMax.position.x, m_character.cameraMax.position.y, m_character.cameraMax.position.z);
        return false;
    }

    public bool CameraMin()
    {
        m_fpsCamera = true;
        transform.position = new Vector3(m_character.cameraMin.position.x, m_character.cameraMin.position.y, m_character.cameraMin.position.z);
        return true;
    }

    public void CameraFPS(float _mouseY, float _mouseX)
    {
        m_mouseY = _mouseY * m_sensitivityY * Time.deltaTime;
        m_mouseX = _mouseX * m_sensitivityX * Time.deltaTime;

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

        transform.Rotate(Vector3.left * m_mouseY);
        m_character.transform.Rotate(Vector3.up * m_mouseX);
    }

    #endregion

    #region PRIVATE METHODS

    private void DetectWallCollisions()
    {
        Vector3 direction = (transform.position - m_character.transform.position);

        RaycastHit[] hit = Physics.RaycastAll(m_character.transform.position, direction.normalized, direction.magnitude);
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

    private void InteractableUpdate()
    {
        RaycastHit hit;
        int layerMask = 0;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, transform.forward, out hit, m_interactableDistance, layerMask))
        {
            Item item = hit.collider.gameObject.GetComponent<Item>();
            if (item && item.CanSeeSpec())
            {
                Color cl = m_aimPoint.color;
                cl.r = 0;
                cl.g = 255;
                m_aimPoint.color = cl;

                item.DisplayCaractOnPickUp();
            }
            else
            {
                ResetInteractable();
            }
        }
        else
        {
            ResetInteractable();
        }
    }

    private void ResetInteractable()
    {
        Color cl = m_aimPoint.color;
        cl.r = 255;
        cl.g = 0;
        m_aimPoint.color = cl;

        GameMediator.Instance.UIManager.EnablePickUpUI(false);
        GameMediator.Instance.UIManager.EnableTooManyItemsUI(false);
    }

    #endregion
}
