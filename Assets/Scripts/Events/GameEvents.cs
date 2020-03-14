
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents m_Current;

    private void Awake()
    {
        m_Current = this;
    }

    public event System.Action OnDoorTriggerEnter;
    public void DoorTriggerEnter()
    {
        if(OnDoorTriggerEnter != null)
        {
            OnDoorTriggerEnter();
        }
    }

    public event System.Action OnDoorTriggerExit;
    public void DoorTriggerExit()
    {
        if (OnDoorTriggerExit != null)
        {
            OnDoorTriggerExit();
        }
    }
}
