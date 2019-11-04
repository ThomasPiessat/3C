using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Helmet(string _name, int _value) : base(_name, _value)
    {
        m_name = _name;
        m_value = _value;
    }

    public override void DisplayCaractOnPickUp()
    {
        base.DisplayCaractOnPickUp();
        GameMediator.Instance.UIManager.EnablePickUpUI(true);
        GameMediator.Instance.UIManager.SetItemSpec(m_name, m_value);
    }
}
