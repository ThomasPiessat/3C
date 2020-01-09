using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region PROPERTIES

    [SerializeField] private GameObject m_inventoryUI = null;
    [SerializeField] private List<GameObject> m_listInventoryPanel = null;
    [SerializeField] private List<Button> m_listInventoryButton = null;

    [SerializeField] private ItemInfo m_itemInfo = null;

    [SerializeField] private Character m_character = null;

    [SerializeField] private ManipulateObject m_ItemButton = null;

    [SerializeField] private TextMeshProUGUI m_CapacityOfInventory = null;

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
            CapacityText();
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

    public void DisplayOnPanel()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent<Sword>())
            {
                InstantiateOnPanel(1, i);
            }
            else if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IArmor)))
            {
                InstantiateOnPanel(2, i);
            }
            else if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IUsable)))
            {
                InstantiateOnPanel(3, i);
            }
            else
            {
                InstantiateOnPanel(4, i);
            }
        }
    }
    public void InstantiateItemButtonInventory()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            Instantiate(m_ItemButton, m_listInventoryPanel[i].transform);
            //with text
            //m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[i].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[i].m_value;
            //with sprite (icon)
            //m_ItemButton.GetComponentInChildren<Image>().sprite = GameMediator.Instance.MainCharacter.m_items[i].m_icon;

        }
    }

    public void DestroyItemButtonInventory()
    {
        Destroy(m_ItemButton.gameObject);
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

    private void CapacityText()
    {
        m_CapacityOfInventory.text = "Capacity : " + GameMediator.Instance.MainCharacter.m_items.Count.ToString() + " / " + GameMediator.Instance.MainCharacter.m_maxItemsToHold.ToString();
    }

    private void InstantiateOnPanel(int _PanelIndex, int _ItemIndex)
    {
        //instantiate on AllItemPanel
        Instantiate(m_ItemButton, m_listInventoryPanel[0].transform);
        Instantiate(m_ItemButton, m_listInventoryPanel[_PanelIndex].transform);
        //with text
        //m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_value;
        //with sprite (icon)
        //m_ItemButton.GetComponentInChildren<Image>().sprite = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_icon;
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
