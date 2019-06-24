using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region PROPERTIES

    [SerializeField] private GameObject m_inventoryUI = null;
    [SerializeField] private List<GameObject> m_listInventoryPanel = null;
    [SerializeField] private List<Button> m_listInventoryButton = null;

    [SerializeField] private ItemInfo m_itemInfo = null;

    #endregion

    #region MONOBEHAVIOUR METHODS

    void Awake()
    {
        m_inventoryUI.SetActive(false);
    }

    #endregion

    #region PUBLIC METHODS

    public void ToggleInventory()
    {
        if (m_inventoryUI.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            m_inventoryUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_inventoryUI.SetActive(true);
            Time.timeScale = 0f;
            ResetPanel();
            DisplayItem();
        }
    }

    public void ChangePanel(int _index)
    {
        if (m_listInventoryPanel[_index] != null && m_listInventoryButton != null)
        {
            for (int i = 0; i < m_listInventoryPanel.Count; i++)
            {
                m_listInventoryPanel[i].SetActive(false);
                m_listInventoryButton[i].GetComponent<Image>().color = Color.white;

                m_listInventoryPanel[_index].SetActive(true);
                m_listInventoryButton[_index].GetComponent<Image>().color = Color.yellow;
            }
        }
    }

    #endregion

    #region PRIVATE METHODS

    private void ResetPanel()
    {
        for (int i = 0; i < m_listInventoryPanel.Count; i++)
        {
            m_listInventoryPanel[i].SetActive(false);
            m_listInventoryButton[i].GetComponent<Image>().color = Color.white;

            m_listInventoryPanel[0].SetActive(true);
            m_listInventoryButton[0].GetComponent<Image>().color = Color.yellow;
        }
    }

    private void DisplayItem()
    {
        Item item = GetComponent<Item>();
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            m_itemInfo.SetItemInfo(item.m_name, item.m_value);
            Instantiate(m_itemInfo, transform.position, Quaternion.identity);
        }
    }

    #endregion
}
