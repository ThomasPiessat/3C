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
    [SerializeField] Vector3 screenPos = Vector3.zero;

    private bool m_IsHighlighted = false;

    Vector3 GetPosition() => Camera.main.ScreenToViewportPoint(screenPos);

    // Start is called before the first frame update
    void Start()
    {
        objectToManipulate.GetComponent<MeshRenderer>().enabled = false;
        objectToManipulate.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(GameMediator.Instance.MainCharacter.transform.position.x + 0, GameMediator.Instance.MainCharacter.transform.position.y + 1, GameMediator.Instance.MainCharacter.transform.position.z + 5);
        screenPos = pos;       
        coordinate = GetPosition();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!objectToManipulate) return;
        objectToManipulate.position = coordinate;
        objectToManipulate.GetComponent<MeshRenderer>().enabled = true;
        //objectToManipulate.GetComponent<BoxCollider>().enabled = true;
        m_IsHighlighted = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectToManipulate.GetComponent<MeshRenderer>().enabled = false;
        //objectToManipulate.GetComponent<BoxCollider>().enabled = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        objectToManipulate.GetComponent<MeshRenderer>().enabled = true;
        //objectToManipulate.GetComponent<BoxCollider>().enabled = true;
    }
}
