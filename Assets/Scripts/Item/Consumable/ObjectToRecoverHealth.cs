using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToRecoverHealth : Consumable
{
    [SerializeField] private float m_HealthToRecover = 0.0f;

    public ObjectToRecoverHealth(string _name, int _value, Sprite _icon) : base(_name, _value, _icon)
    {
        m_IsStackable = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DisplayCaractOnPickUp()
    {
        base.DisplayCaractOnPickUp();
        GameMediator.Instance.UIManager.EnablePickUpUI(true);
        GameMediator.Instance.UIManager.SetItemSpec(m_name, m_value);
    }

}
