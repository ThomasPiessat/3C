using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item, IWeapon
{
    #region ATTRIBUTES

    [SerializeField] protected float m_attackSpeedNeeded = 0f;

    #endregion

    #region PROPERTIES



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

    #region PUBLIC METHODS


    public void Attack(int _damage)
    {

    }

    public override void DisplayCaractOnPickUp()
    {

    }

    #endregion
}
