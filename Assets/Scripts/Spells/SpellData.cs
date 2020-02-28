using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellData : ScriptableObject
{
    public GameObject Prefab;
    public Sprite Icon = null;
    public string Name;
    public int ManaCost;
    public float Cooldown;
    public float AttackRange;
}
