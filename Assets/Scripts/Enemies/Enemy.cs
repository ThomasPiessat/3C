using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    #region ATTRIBUTES

    [Header("Stats")]
    [SerializeField] private float m_speed = 0f;
    [SerializeField] private float m_maxHealth = 0f;
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

    #region PRIVATE METHODS



    #endregion

    #region PUBLIC METHODS

    public void TakeDamage(float _damageTaken)
    {
        Debug.Log("aiTakeDamage health : " + m_maxHealth);
        m_maxHealth -= _damageTaken;
        if (m_maxHealth <= 0)
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


}
