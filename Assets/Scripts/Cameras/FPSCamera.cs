using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    #region ATTRIBUTES

    public CameraFPSData m_CameraFPSData;

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

    #region PUBLIC METHODS



    #endregion

    #region PRIVATE METHODS

    private void Control(float _MouseY, float _MouseX)
    {
        float mouseY = _MouseY * m_CameraFPSData.m_SensitivityY * Time.deltaTime;
        float mouseX = _MouseX * m_CameraFPSData.m_SensitivityX * Time.deltaTime;

        m_CameraFPSData.m_ClampX += mouseY;

        if(m_CameraFPSData.m_ClampX > m_CameraFPSData.m_MinX)
        {
            m_CameraFPSData.m_ClampX = m_CameraFPSData.m_MinX;
            mouseY = 0.0f;
        }

        transform.Rotate(Vector3.left * mouseY);
        m_CameraFPSData.Target.transform.Rotate(Vector3.up * mouseX);
    }

    #endregion
}
