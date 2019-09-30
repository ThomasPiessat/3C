using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraTest : MonoBehaviour
{
    [SerializeField] private ThirdPersonCharacter m_thirdPersonCharacter = null;

    [SerializeField] private float m_defaultDistanceToPlayer = 2.5f;
    [SerializeField] private float m_xClampValue = 35f;

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
        //Debug.Log(Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position));

        if (Vector3.Distance(transform.position, m_thirdPersonCharacter.transform.position) <= 10.1f)
        {
            transform.Translate(Vector3.forward * _wheelSpeed * 100 * Time.deltaTime);
        }
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
