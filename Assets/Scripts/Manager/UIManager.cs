using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region ATTRIBUTES

    private static UIManager m_instanceUiManager = null;

    [Header("UIPanel")]
    [SerializeField] private GameObject m_tooManyItems = null;
    [SerializeField] private GameObject m_PickUpCaract = null;

    [Header("CaractItemUI")]
    [SerializeField] private TextMeshProUGUI m_itemNameTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemValueTMP = null;
    //Damage/Armor
    [SerializeField] private TextMeshProUGUI m_itemSpecTMP = null;

    #endregion

    #region PROPERTIES



    #endregion

    #region MONOBEHAVIOUR METHODS

    private void Awake()
    {
        EnablePickUpUI(false);
        EnableTooManyItemsUI(false);
    }

    private void Start()
    {
        
    }

    #endregion

    #region PUBLIC METHODS

    public void SetItemSpec(string _itemName, int _itemValue)
    {
        m_itemNameTMP.text = _itemName.ToString();
        m_itemValueTMP.text = "Value : " + _itemValue.ToString();
    }

    public void SetItemName(string _itemName)
    {
        m_itemNameTMP.text = _itemName.ToString();  
    }

    #region EnableUIMethods

    public void EnablePickUpUI(bool _value)
    {
        m_PickUpCaract.SetActive(_value);
    }

    public void EnableTooManyItemsUI(bool _value)
    {
        m_tooManyItems.SetActive(_value);
    }

    #endregion   

    #endregion
}
