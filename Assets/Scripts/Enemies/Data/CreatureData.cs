using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName ="New Creature Data", menuName ="Enemy Data/Creature")]
public class CreatureData : EnemyData
{
    public CreatureType Type;
}
