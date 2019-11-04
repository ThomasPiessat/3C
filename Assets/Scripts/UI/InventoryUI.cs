using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region PROPERTIES

    [SerializeField] private GameObject m_inventoryUI = null;
    [SerializeField] private List<GameObject> m_listInventoryPanel = null;
    [SerializeField] private List<Button> m_listInventoryButton = null;

    [SerializeField] private ItemInfo m_itemInfo = null;

    [SerializeField] private Character m_character = null;

    [SerializeField] private Button m_ItemButton = null;

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
            //DisplayItem();           
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
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            Instantiate(m_itemInfo, m_listInventoryPanel[i].transform);
            m_itemInfo.SetItemInfo(GameMediator.Instance.MainCharacter.m_items[0].m_name, GameMediator.Instance.MainCharacter.m_items[0].m_value);
        }
    }

    private void InstantiateItemButtonInventory()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            Instantiate(m_ItemButton, m_listInventoryPanel[i].transform);
            m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[0].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[0].m_value;
        }
    }

    private void SortInventory()
    {
        var sortResult = m_character.m_items.OrderBy(a => a.m_name);
    }

    private void ChangeOrderSort()
    {
        //Press a button change the sort system (byName, byValue, ascending/descending)
    }

    #endregion

}
