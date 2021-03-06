﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : Item, IWeapon
{
    #region ATTRIBUTES

    [SerializeField] protected float m_attackSpeedNeeded = 0f;
    private Animator m_animator = null;

    #endregion

    #region PROPERTIES



    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region PUBLIC METHODS

    public Sword(string _name, int _value, Sprite _icon) : base(_name, _value, _icon)
    {
        m_IsStackable = false;
    }

    public void Attack(int _damage)
    {
        m_animator.SetTrigger("IsAttacking");
    }

    public override void DisplayCaractOnPickUp()
    {
        base.DisplayCaractOnPickUp();
        GameMediator.Instance.UIManager.EnablePickUpUI(true);
        GameMediator.Instance.UIManager.SetItemSpec(m_name, m_value);
    }

    #endregion
}
