using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int value = (int) m_Keycode;
        Debug.Log($"int / keycode : {value.ToString()} / {((KeyCode)value).ToString()}");
    }

    void OnGUI()
    {
        Event c = Event.current;
        m_String = "char : " + c.character.ToString() + "\n";

        m_String += "shift : " + (c.shift) + "\n";
        m_String += "alt : " + c.alt + "\n";
        m_String += "ctrl : " + c.control + "\n";
        m_String += "F? : " + c.functionKey + "\n";

        Debug.Log((m_String));


    }

    void Update()
    {
        foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kc))
            {
                m_ReaderCode = kc;
            }
        }
    }

    public KeyCode m_Keycode;
    public KeyCode m_ReaderCode = KeyCode.None;
    public string m_String = string.Empty;
}
