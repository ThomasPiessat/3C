using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class ManipulateObject : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerClickHandler
{
    public Transform m_ObjectToManipulate = null;

    [SerializeField, Header("Position X from screen"), Range(0, 1920)] float xPosition = 0;
    [SerializeField, Header("Position Y from screen"), Range(0, 1080)] float yPosition = 0;
    [SerializeField, Header("Position Z from screen"), Range(0, 100)] float zPosition = 5;

    [SerializeField] private Vector3 m_Coordinate = Vector3.zero;
    private bool m_IsHighlighted = false;
    private bool m_IsInstantiate = false;

    void SetPosition() => m_ObjectToManipulate.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition / 2, zPosition));


    // Start is called before the first frame update
    void Start()
    {
        SetObjectToManipulate();
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
        //Vector3 pos = new Vector3(GameMediator.Instance.MainCharacter.transform.position.x + 0, GameMediator.Instance.MainCharacter.transform.position.y + 2, GameMediator.Instance.MainCharacter.transform.position.z + 5);
        //m_Coordinate = Camera.main.ViewportToWorldPoint(pos);
        if (m_IsHighlighted)
        {
            m_ObjectToManipulate.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                m_ObjectToManipulate.eulerAngles -= new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            }
        }
    }

    void SetPosition(Camera _camera)
    {
        if (!_camera) return;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, zPosition));
    }

    //Hovered
    public void OnPointerEnter(PointerEventData eventData)
    {

    }



    public void OnSelect(BaseEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!m_IsHighlighted && !m_IsInstantiate)
        {
            if (!m_ObjectToManipulate) return;
            Instantiate(m_ObjectToManipulate, m_Coordinate, Quaternion.identity);
            m_ObjectToManipulate.gameObject.SetActive(true);
            m_ObjectToManipulate.position = m_Coordinate;
            m_ObjectToManipulate.GetComponent<MeshRenderer>().enabled = true;
            //objectToManipulate.GetComponent<BoxCollider>().enabled = true;
            m_IsHighlighted = true;
            m_IsInstantiate = true;
        }
        else if (m_IsInstantiate)
        {
            m_ObjectToManipulate.GetComponent<MeshRenderer>().enabled = false;
            Destroy(m_ObjectToManipulate);
            m_IsHighlighted = false;
            m_IsInstantiate = false;
        }
    }

    private void SetObjectToManipulate()
    {
        m_ObjectToManipulate = GameMediator.Instance.MainCharacter.m_items[0].transform;
    }


}
