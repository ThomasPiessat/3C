using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    public List<TMP_Dropdown> m_listInputDP = null;

    public List<Button> m_listInputButton = null;


    private bool m_isAssign = false;
    private int m_IndexToAssign = 0;

    private static InputUI m_Instance = null;

    public static InputUI Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        //SetInput();
        //AddCallbacks();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInputText();
    }


    // Update is called once per frame
    void Update()
    {
        AssignNewInput();
    }

    #region WithDropDown

    private void SetInput()
    {
        Debug.Log(("SetInputs", gameObject));
        for (int i = 0; i < GameMediator.Instance.Controller.m_controlKey.Count; i++)
        {
            Debug.Log(GameMediator.Instance.Controller.m_controlKey[i]);
        }

        for (int k = 0; k < m_listInputDP.Count; k++)
        {
            m_listInputDP[k].options.Clear();

            for (KeyCode i = KeyCode.A; i <= KeyCode.Z; i++)
            {
                m_listInputDP[k].options.Add(new TMP_Dropdown.OptionData(i.ToString()));
            }


            m_listInputDP[k].value = (int)GameMediator.Instance.Controller.m_controlKey[k] - (int)KeyCode.A;
        }
    }

    private void AddCallbacks()
    {
        for (int i = 0; i < m_listInputDP.Count; i++)
        {
            m_listInputDP[i].onValueChanged.AddListener((value) => ChangeControllerInput());
        }
    }

    //In control menu player can change keyboard input
    public void ChangeControllerInput()
    {
        for (int i = 0; i < m_listInputDP.Count; i++)
        {
            GameMediator.Instance.Controller.m_controlKey[i] = (KeyCode)(m_listInputDP[i].value + (int)KeyCode.A);
        }
    }

    #endregion

    #region WithButton

    private void SetInputText()
    {
        for (int i = 0; i < m_listInputButton.Count; i++)
        {
            m_listInputButton[i].GetComponentInChildren<TMP_Text>().SetText(GameMediator.Instance.Controller.m_controlKey[i].ToString());
        }
    }

    public void AssignInput(int _index)
    {
        m_IndexToAssign = _index;
        m_listInputButton[_index].GetComponentInChildren<TMP_Text>().SetText("");
        m_listInputButton[_index].GetComponent<Image>().color = Color.red;
        m_isAssign = true;

    }

    public void AssignNewInput()
    {
        if (m_isAssign)
        {
            foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kc))
                {
                    SetText(kc);
                    m_isAssign = false;
                }
            }
        }
    }

    private void SetText(KeyCode _newKeyCode)
    {
        m_listInputButton[m_IndexToAssign].GetComponentInChildren<TMP_Text>().SetText(_newKeyCode.ToString());
        m_listInputButton[m_IndexToAssign].GetComponent<Image>().color = Color.white;
        SetPlayerInput(_newKeyCode);
    }

    private void SetPlayerInput(KeyCode _newKeyCode)
    {
        GameMediator.Instance.Controller.m_controlKey[m_IndexToAssign] = _newKeyCode;
    }

    public void UpdateText(List<KeyCode> _ListKC)
    {

    }

    //reset player input by default (ZQSD)
    public void ResetDefaut()
    {

    }

    #endregion
}
