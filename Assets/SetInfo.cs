using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetInfo : MonoBehaviour
{	
	#region PUBLIC METHODS

    public void SetInfoItem(string _itemName)
    {
        GetComponent<TextMeshProUGUI>().text = _itemName;
    }
	 
	#endregion
}
