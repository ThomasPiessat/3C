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
    [SerializeField] private GameObject m_CharacterSpec = null;
    [SerializeField] private Character m_character = null;

    [Tooltip("List of Panels of all categories of the inventory")]
    [SerializeField] private List<GameObject> m_listInventoryPanel = null;

    [Tooltip("List of ScrollView of all categories panels of the inventory")]
    [SerializeField] private List<GameObject> m_listScrollView = null;

    [Tooltip("List of Buttons of all categories of the inventory")]
    [SerializeField] private List<Button> m_listInventoryButton = null;

    [Tooltip("ItemInfo Prefab")]
    [SerializeField] private ItemInfo m_itemInfo = null;

    [Tooltip("Button of the item in inventory prefab")]
    [SerializeField] private Button m_ItemButton = null;

    //m_ListButtonInventory.Count == m_ListItemInInventoryPlayer.Count
    [Tooltip("List button in all panel")]
    [SerializeField] private List<Button> m_ListButtonInventory = new List<Button>();


    [SerializeField] private TextMeshProUGUI m_CapacityOfInventory = null;

    #endregion

    #region MONOBEHAVIOUR METHODS

    void Awake()
    {
        m_inventoryUI.SetActive(false);
        m_CharacterSpec.SetActive(false);
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
            m_CharacterSpec.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_inventoryUI.SetActive(true);
            m_CharacterSpec.SetActive(true);
            DisplayAllItemInInventory();
            ResetPanel();
            CapacityText();
            Time.timeScale = 0f;
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


    //public void InstantiateItemInfo()
    //{
    //    Instantiate(m_itemInfo);
    //}

    //public void DestroyItemInfo()
    //{
    //    Destroy(m_itemInfo);
    //}

    //public void DisplayItemInfo()
    //{
    //    for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
    //    {
    //        m_itemInfo.SetItemInfo(i);
    //    }
    //}

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

    private void DisplayAllItemInInventory()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IWeapon)))
            {
                InstantiateItemButtonOnPanel(1, i);
            }
            else if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IArmor)))
            {
                InstantiateItemButtonOnPanel(2, i);
            }
            else if (GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IUsable)))
            {
                InstantiateItemButtonOnPanel(3, i);
            }
            else
            {
                InstantiateItemButtonOnPanel(4, i);
            }
            DestroyItemButtonInventory(i);
        }
    }

    private void InstantiateItemButtonOnPanel(int _PanelIndex, int _ItemIndex)
    {
        //instantiate on AllItemPanel
        Instantiate(m_ItemButton, m_listScrollView[0].transform);
        Instantiate(m_ItemButton, m_listScrollView[_PanelIndex].transform);
        //with text
        m_ItemButton.GetComponent<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_value;
        //with sprite (icon)
        //m_ItemButton.GetComponent<Image>().sprite = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_icon;
    }

    //Display pick up item in inventory
    private void InstantiateItemButtonInventory()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            Instantiate(m_ItemButton, m_listInventoryPanel[i].transform);
            //Set item info in inventory
            //with text
            //m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[i].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[i].m_value;
            //with sprite (icon)
            m_ItemButton.GetComponent<Image>().sprite = GameMediator.Instance.MainCharacter.m_items[i].m_icon;
        }
    }

    //== Clear
    private void DestroyItemButtonInventory(int _Index)
    {
        Destroy(m_ItemButton.gameObject);
    }

    private void OnMove()
    {

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
