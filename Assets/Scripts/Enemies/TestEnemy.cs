using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IDamageable
{
    #region ATTRIBUTES

    public float Health = 0.0f;
    public float MaxHealth = 0.0f;
    public float Speed = 0.0f;
    public float MaxSpeed = 0.0f;
    public int Attack = 0;
    public int Armor = 0;
    public float AttackRange = 0.0f;

    private bool m_isDead = false;

    #endregion

    #region PROPERTIES



    #endregion

    #region MONOBEHAVIOUR METHODS

    void Start()
    {

    }


    void Update()
    {

    }

    #endregion

    #region PUBLIC METHODS

    public void TakeDamage(float _damageTaken)
    {
        Debug.Log("aiTakeDamage health : " + MaxHealth);
        MaxHealth -= _damageTaken;
        if (MaxHealth <= 0)
        {
            m_isDead = true;
            Die();
        }
    }

    public void Die()
    {
        Destroy(this);
    }

    #endregion

    #region PRIVATE METHODS



    #endregion
}
