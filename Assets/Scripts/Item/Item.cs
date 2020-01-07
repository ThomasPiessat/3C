using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region ATTRIBUTES


    #endregion

    #region PROPERTIES

    public string m_name = "";
    public int m_value = 0;
    public Sprite m_icon = null;

    protected bool m_IsStackable = false;

    #endregion

    public bool GetIsStackable
    {
        get
        {
            return m_IsStackable;
        }
    }

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

    public Item(string _name, int _value, Sprite _icon)
    {
        m_name = _name;
        m_value = _value;
        m_icon = _icon;
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
