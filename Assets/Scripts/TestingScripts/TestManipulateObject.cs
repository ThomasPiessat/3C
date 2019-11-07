using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class TestManipulateObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    [SerializeField] private Transform objectToManipulate = null;
    [SerializeField] Vector3 coordinate = Vector3.zero;

    private bool m_IsHighlighted = false;

    // Start is called before the first frame update
    void Start()
    {
        objectToManipulate.GetComponent<MeshRenderer>().enabled = false;
        objectToManipulate.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(GameMediator.Instance.MainCharacter.transform.position.x + 0, GameMediator.Instance.MainCharacter.transform.position.y + 200, GameMediator.Instance.MainCharacter.transform.position.z + 5);
        coordinate = Camera.main.ScreenToViewportPoint(pos);
        if (m_IsHighlighted)
        {
            objectToManipulate.GetComponent<MeshRenderer>().enabled = true;            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("ObjectOnClicked");
                objectToManipulate.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!m_IsHighlighted)
        {
            if (!objectToManipulate) return;
            objectToManipulate.position = coordinate;
            objectToManipulate.GetComponent<MeshRenderer>().enabled = true;
            //objectToManipulate.GetComponent<BoxCollider>().enabled = true;
            m_IsHighlighted = true;
        }
        else
            m_IsHighlighted = false;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectToManipulate.GetComponent<MeshRenderer>().enabled = false;
        //objectToManipulate.GetComponent<BoxCollider>().enabled = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        //objectToManipulate.GetComponent<MeshRenderer>().enabled = true;
        //objectToManipulate.GetComponent<BoxCollider>().enabled = true;
    }
}
