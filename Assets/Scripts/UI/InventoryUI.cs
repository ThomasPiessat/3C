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

    [SerializeField] private Button m_ItemButton = null;

    [SerializeField] private TextMeshProUGUI m_CategoryWhereAreWe = null;
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

    private void CapacityText()
    {
        m_CapacityOfInventory.text = GameMediator.Instance.MainCharacter.m_items.Count.ToString() + " / " + GameMediator.Instance.MainCharacter.m_maxItemsToHold.ToString();
    }

    public void DisplayOnRightPanel()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            if(GameMediator.Instance.MainCharacter.m_items[i].GetComponent<Sword>())
            {
                Instantiate(m_ItemButton, m_listInventoryPanel[0].transform);
                Instantiate(m_ItemButton, m_listInventoryPanel[1].transform);
                m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[i].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[i].m_value;

            }
            else if(GameMediator.Instance.MainCharacter.m_items[i].GetComponent(typeof(IArmor)))
            {
                Instantiate(m_ItemButton, m_listInventoryPanel[0].transform);
                Instantiate(m_ItemButton, m_listInventoryPanel[2].transform);
                m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[i].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[i].m_value;
            }
        }
    }

    public void InstantiateItemButtonInventory()
    {
        for (int i = 0; i < GameMediator.Instance.MainCharacter.m_items.Count; i++)
        {
            Instantiate(m_ItemButton, m_listInventoryPanel[i].transform);
            m_ItemButton.GetComponentInChildren<TextMeshProUGUI>().text = GameMediator.Instance.MainCharacter.m_items[i].m_name + " : " + GameMediator.Instance.MainCharacter.m_items[i].m_value;
        }
    }

    public void DestroyItemButtonInventory()
    {
        Destroy(m_ItemButton.gameObject);
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
