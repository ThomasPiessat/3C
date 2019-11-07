using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private bool m_ReadInput = false;
    private List<KeyCode> m_Keys = new List<KeyCode>();
    private Func<List<KeyCode>, bool> m_Callback = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ReadInput)
        {
            KeyCode keypress = KeyCode.None;
            if(Input.anyKeyDown)
            {
                keypress = InputExtension.GetKeyDown();
                m_Keys.Add(keypress);
            }
            if(m_Keys.Count>0&&Input.GetKeyUp(m_Keys[m_Keys.Count - 1]))
            {
                bool? result = m_Callback?.Invoke(m_Keys);
                m_ReadInput = !result.HasValue || !result.Value;
                if(!m_ReadInput)
                {
                    InputUI.Instance.UpdateText(m_Keys);
                }
            }
        }
    }

    private void EnableInputReading()
    {
        m_ReadInput = true;
        m_Keys.Clear();
    }
}
