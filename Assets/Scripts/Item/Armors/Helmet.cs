using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helmet : Item, IArmor
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Helmet(string _name, int _value, Sprite _icon) : base(_name, _value, _icon)
    {
        m_IsStackable = false;
    }

    public override void DisplayCaractOnPickUp()
    {
        base.DisplayCaractOnPickUp();
        GameMediator.Instance.UIManager.EnablePickUpUI(true);
        GameMediator.Instance.UIManager.SetItemSpec(m_name, m_value);
    }
}
