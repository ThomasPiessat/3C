using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region ATTRIBUTES


    #endregion

    #region PROPERTIES

    public string m_name = "";
    public int m_value = 0;

    protected bool m_IsStackable = false;

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

    public Item(string _name, int _value)
    {
        m_name = _name;
        m_value = _value;
    }

    #region PROTECTED METHODS

    public virtual void DisplayCaractOnPickUp()
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
