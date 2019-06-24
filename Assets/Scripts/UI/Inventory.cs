using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region ATTRIBUTES

	
	
    #endregion
	
	#region PROPERTIES

    [SerializeField] private GameObject m_inventoryUI = null;

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (m_inventoryUI.activeSelf)
        {
            m_inventoryUI.SetActive(false);
        }
        else
        {
            m_inventoryUI.SetActive(true);
        }
    }



    #endregion

    #region PRIVATE METHODS



    #endregion
}
