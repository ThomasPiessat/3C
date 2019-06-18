using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_PickUpCaract = null;
    [SerializeField] private GameObject m_Inventory = null;

    [Header("CaractItemUI")]
    [SerializeField] private TextMeshProUGUI m_itemNameTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemValueTMP = null;
    //Damage/Armor
    [SerializeField] private TextMeshProUGUI m_itemSpecTMP = null;

    #region PUBLIC METHODS

    public void SetItemSpec(string _itemName, int _itemValue, int _itemSpec)
    {
        m_itemNameTMP.text = _itemName.ToString();
        m_itemValueTMP.text = _itemValue.ToString();
        m_itemSpecTMP.text = _itemSpec.ToString();
    }

    public void EnablePickUpUI(bool _value)
    {
        m_PickUpCaract.SetActive(_value);
    }

    public void EnableInventoryUI()
    {

    }

    #endregion
}
