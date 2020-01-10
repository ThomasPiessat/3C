using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private TextMeshProUGUI m_itemNameTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemSpecTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemValueTMP = null;

    #endregion
	
	#region PROPERTIES
	
	

	#endregion

    #region PUBLIC METHODS

    public void SetItemInfo(int _ItemIndex)
    {
        m_itemNameTMP.text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_name;
        //m_itemSpecTMP.text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_spec;
        m_itemValueTMP.text = "Value : " + GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_value.ToString();       
    }
	 
	#endregion
}
