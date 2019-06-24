using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private TextMeshProUGUI m_itemNameTMP = null;
    [SerializeField] private TextMeshProUGUI m_itemValueTMP = null;

    #endregion
	
	#region PROPERTIES
	
	

	#endregion
	
	#region MONOBEHAVIOUR METHODS
	
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	#endregion
	
	#region PRIVATE METHODS

    public void SetItemInfo(string _itemName, int _itemValue)
    {
        m_itemNameTMP.text = _itemName.ToString();
        m_itemValueTMP.text = "Value : " + _itemValue.ToString();
    }
	 
	#endregion
}
