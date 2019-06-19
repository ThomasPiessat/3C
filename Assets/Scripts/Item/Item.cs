using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region ATTRIBUTES

	
    #endregion
	
	#region PROPERTIES

    [SerializeField] public string m_itemName { get; set; }
    [SerializeField] protected int m_value = 0;   



	#endregion
	
	#region MONOBEHAVIOUR METHODS
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region PROTECTED METHODS

    protected virtual void DisplayCaractOnPickUp()
    {
        
    }

    protected virtual void DisplayCaractOnInventory()
    {

    }

    #endregion

    public virtual bool CanSeeSpec()
    {
        return true;
    }

}
