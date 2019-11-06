using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMoveUIElement : MonoBehaviour
{
    [SerializeField] private Vector3 screenPos = Vector3.zero;
    [SerializeField] private Transform objectToManipulate = null;
    [SerializeField] private Button m_MovableButton = null;
    [SerializeField] private Vector3 coordinate = Vector3.zero;

    Vector3 GetPosition() => Camera.main.ScreenToViewportPoint(screenPos);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coordinate = GetPosition();

        m_MovableButton.onClick.AddListener(MoveUI);
    }

    private void MoveUI()
    {
        Vector3 worldPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        worldPos.z = 0;
        m_MovableButton.GetComponent<RectTransform>().transform.position += worldPos;
    }

    void SetObjectRotation()
    {
        if (!objectToManipulate) return;
        objectToManipulate.position = coordinate;
        if (Input.GetKey(KeyCode.Mouse0))
            objectToManipulate.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    }

}
