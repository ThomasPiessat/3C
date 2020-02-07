using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{

    public GameObject Prefab;
    public float Health;
    public float MaxHealth;
    public float Speed;
    public float MaxSpeed;
    public int Attack;
    public int Armor;
    public float AttackRange;
    public string Name;
}
