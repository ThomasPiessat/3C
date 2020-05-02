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
    [SerializeField] private List<GameObject> m_listScrollViewContent = null;

    [Tooltip("List of Buttons of all categories of the inventory")]
    [SerializeField] private List<Button> m_listInventoryButton = null;

    [Tooltip("ItemInfo Prefab")]
    [SerializeField] private ItemInfo m_itemInfo = null;

    [Tooltip("Button of the item in inventory prefab")]
    [SerializeField] private Button m_ItemButton = null;

    //m_ListButtonInventory.Count == m_ListItemInInventoryPlayer.Count
    private List<Button> m_ListItemsButtonAllCat = new List<Button>();
    private List<Button> m_ListItemsButtonWeapon = new List<Button>();

    [SerializeField] private TextMeshProUGUI m_CapacityOfInventory = null;

    #endregion

    #region MONOBEHAVIOUR METHODS

    void Awake()
    {
        m_inventoryUI.SetActive(false);
        m_CharacterSpec.SetActive(false);
    }

    private void Update()
    {
        CheckInventoryButtonCount();
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

    private void CheckInventoryButtonCount()
    {
        //Debug.Log("Player = " + GameMediator.Instance.MainCharacter.m_listItems.Count);
        //Debug.Log("UI = " + m_ListItemsButton.Count);

        if (m_ListItemsButtonAllCat.Count == GameMediator.Instance.MainCharacter.m_listItems.Count)
        {
            Debug.Log("Display/Enable");
        }
        else if (m_ListItemsButtonAllCat.Count < GameMediator.Instance.MainCharacter.m_listItems.Count)
        {
            Debug.Log("Pas asser de btn");
            InstantiateItemsButtonOnRightPanel();
            AssignCharacteristicsButton();
        }
            
        else if (m_ListItemsButtonAllCat.Count > GameMediator.Instance.MainCharacter.m_listItems.Count)
            Debug.Log("Trop de btn");

    }

    private void InstantiateItemsButton(int _Index)
    {
        Instantiate(m_ItemButton, m_listScrollViewContent[_Index].transform);
        m_ListItemsButtonAllCat.Add(m_ItemButton);
    }

    private void DestroyItemButtonInventory(int _Index)
    {
        Destroy(m_ItemButton.gameObject);
        m_ListItemsButtonAllCat.Remove(m_ItemButton);
    }

    private void InstantiateItemsButtonOnRightPanel()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_listItems.Count; i++)
        {
            if (GameMediator.Instance.MainCharacter.m_listItems[i].GetComponent(typeof(IWeapon)))
            {
                InstantiateItemsButton(i);
                m_ListItemsButtonWeapon.Add(m_ItemButton);
            }
            else if (GameMediator.Instance.MainCharacter.m_listItems[i].GetComponent(typeof(IArmor)))
            {
                InstantiateItemsButton(i);
            }
            else if (GameMediator.Instance.MainCharacter.m_listItems[i].GetComponent(typeof(IUsable)))
            {
                InstantiateItemsButton(i);
            }
            else
            {
                InstantiateItemsButton(i);
            }
        }
    }

    private void AssignCharacteristicsButton()
    {
        for (int i = 0; i < m_ListItemsButtonAllCat.Count; i++)
        {
            Image iconItem = m_ListItemsButtonAllCat[i].transform.GetChild(0).GetComponent<Image>();
            TextMeshProUGUI nameItem = m_ListItemsButtonAllCat[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            if(iconItem && nameItem)
            {
                iconItem.sprite = GameMediator.Instance.MainCharacter.m_listItems[i].m_icon;
                nameItem.text = GameMediator.Instance.MainCharacter.m_listItems[i].m_name;
            }
        }
    }
    private void InstantiateItemButtonOnPanel(int _PanelIndex, int _ItemIndex)
    {
        Image iconItem = m_ItemButton.transform.GetChild(0).GetComponent<Image>();
        TextMeshProUGUI nameItemTxt = m_ItemButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        nameItemTxt.text = GameMediator.Instance.MainCharacter.m_listItems[0].m_name;
        iconItem.sprite = GameMediator.Instance.MainCharacter.m_listItems[0].m_icon;
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
