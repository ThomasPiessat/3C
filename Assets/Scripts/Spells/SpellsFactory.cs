using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpellsTypes
{
    public enum SpellsType
    {
        Damage,
        Healing,
        stun
    }
}

public struct SpellsStats
{
    public string m_Name;
    public float m_ManaCost;
    public float m_Cooldown;
}

public class SpellsFactory
{
    public static Spells CreateSpells(Spells.AllSpells _Spells)
    {
        switch (_Spells)
        {
            case Spells.AllSpells.FireBall:
                return new Spells("FireBall", 12);             
            case Spells.AllSpells.IceBall:
                return new Spells("IceBall", 13);
            case Spells.AllSpells.Healing:
                return new Spells("Healing", 15);
            default:
                break;
        }
        return null;
    }
}
