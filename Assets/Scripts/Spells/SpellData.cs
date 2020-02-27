using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellData : ScriptableObject
{
    public GameObject Prefab;
    public Sprite m_Icon = null;
    public string m_Name;
    public int m_ManaCost;
    public float m_Cooldown;
    public float m_AttackRange;
}
