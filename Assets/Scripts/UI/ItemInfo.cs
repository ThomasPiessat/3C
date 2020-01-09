using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private GameObject m_panelInfo = null;
    [SerializeField] private TextMeshProUGUI m_itemNameTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemSpecTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemValueTMP = null;

    #endregion
	
	#region PROPERTIES
	
	

	#endregion
	
	#region MONOBEHAVIOUR METHODS
	
    void Awake()
    {
        SetEnablePanel(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region MyRegion

    public void SetEnablePanel(bool _Value)
    {
        m_panelInfo.SetActive(_Value);
    }

    #endregion

    #region PRIVATE METHODS

    private void SetItemInfo(int _ItemIndex)
    {
        m_itemNameTMP.text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_name;
        //m_itemSpecTMP.text = GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_spec;
        m_itemValueTMP.text = "Value : " + GameMediator.Instance.MainCharacter.m_items[_ItemIndex].m_value.ToString();       
    }
	 
	#endregion
}
