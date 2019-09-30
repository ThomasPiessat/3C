using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private static InputManager m_instanceInputManager = null;

    [SerializeField] public List<TMP_Dropdown> m_listInputDP = null;

    private void Awake()
    {
        SetInput();
    }

    private void Start()
    {
        SetDefautInput();
    }

    private void Update()
    {
        SetInput();
    }

    public void SetInput()
    {
        for (int k = 0; k < m_listInputDP.Count; k++)
        {
            m_listInputDP[k].options.Clear();

            for (KeyCode i = KeyCode.A; i <= KeyCode.Z; i++)
            {
                m_listInputDP[k].options.Add(new TMP_Dropdown.OptionData(i.ToString()));
            }
        }
    }

    public void SetDefautInput()
    {
        for (int k = 0; k < m_listInputDP.Count; k++)
        {
            for (int i = 0; i < GameMediator.Instance.TPSController.m_controlKey.Count; i++)
            {
                //m_listInputDP[k].value = (int) GameMediator.Instance.TPSController.moveBwd - (int) KeyCode.A;
                //m_listInputDP[k].value = (int)GameMediator.Instance.TPSController.m_controlKey[i] - (int)KeyCode.A;
            }
        }
    }

    //In control menu player can change keyboard input
    public void ChangeInput()
    {
        for (int i = 0; i < m_listInputDP.Count; i++)
        {
            GameMediator.Instance.TPSController.m_controlKey[i] = (KeyCode)(m_listInputDP[i].value + (int)KeyCode.A);
        }
    }
}
