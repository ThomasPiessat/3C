using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    #region PROPERTIES

    [SerializeField] private GameObject m_pauseUI = null;
    [SerializeField] private GameObject m_optionUI = null;

    [SerializeField] private List<GameObject> m_panelList = null;
    [SerializeField] private List<GameObject> m_buttonList = null;


    #endregion

    #region MONOBEHAVIOUR METHODS

    private void Awake()
    {

    }

    void Start()
    {
        m_optionUI.SetActive(false);
    }

    #endregion


    #region PUBLIC METHODS

    public void Return()
    {
        m_pauseUI.SetActive(true);
        m_optionUI.SetActive(false);
    }

    public void ChangePanel(int _index)
    {
        if (m_panelList[_index] != null && m_buttonList != null)
        {
            for (int i = 0; i < m_panelList.Count; i++)
            {
                m_panelList[i].SetActive(false);
                m_buttonList[i].GetComponent<Image>().color = Color.white;

                m_panelList[_index].SetActive(true);
                m_buttonList[_index].GetComponent<Image>().color = Color.red;
            }
        }
    }


    #endregion
}
