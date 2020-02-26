using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public enum AllSpells
    {
        FireBall,
        IceBall,
        Healing
    }

    #region PROPERTIES

    protected string m_Name = "";
    protected float m_ManaCost = 0.0f;
    protected float m_Cooldown = 0.0f;
    protected Sprite m_Icon = null;

    #endregion


    public Spells(string _Name, int _ManaCost/*, Sprite _Icon*/)
    {
        m_Name = _Name;
        m_ManaCost = _ManaCost;
        //m_Icon = _Icon;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSpellsStats(SpellsStats _spellsStats)
    {
        m_Name = _spellsStats.m_Name;
        m_ManaCost = _spellsStats.m_ManaCost;
        m_Cooldown = _spellsStats.m_Cooldown;
    }
}
