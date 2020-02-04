using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item, IUsable
{
    public Consumable(string _name, int _value, Sprite _icon) : base(_name, _value, _icon)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanUse()
    {
        throw new System.NotImplementedException();
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }

}
