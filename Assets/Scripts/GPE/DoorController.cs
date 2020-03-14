using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.m_Current.OnDoorTriggerEnter += OnDoorOpen;
        GameEvents.m_Current.OnDoorTriggerExit += OnDoorExit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDoorOpen()
    {
        transform.position += transform.up * 5f;
    }

    private void OnDoorExit()
    {
        transform.position -= transform.up * 5f;
    }

    private void OnDestroy()
    {
        GameEvents.m_Current.OnDoorTriggerEnter -= OnDoorOpen;
        GameEvents.m_Current.OnDoorTriggerExit -= OnDoorExit;
    }
}
