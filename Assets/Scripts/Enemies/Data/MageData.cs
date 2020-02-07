using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Mage Data", menuName = "Enemy Data/Mage")]
public class MageData : EnemyData
{
    public MageType Type;
}
