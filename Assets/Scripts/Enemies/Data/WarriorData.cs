using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "Enemy Data/Warrior")]
public class WarriorData : EnemyData
{
    public WarriorType Type;
    public WarriorWpn Weapon;
}
