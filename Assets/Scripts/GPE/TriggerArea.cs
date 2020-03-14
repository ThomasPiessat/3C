using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.m_Current.DoorTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.m_Current.DoorTriggerExit();
    }
}
