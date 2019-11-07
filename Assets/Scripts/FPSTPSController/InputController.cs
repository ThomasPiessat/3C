using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Axis
{

}

[System.Serializable]
public struct Action
{
    public readonly static List<KeyCode> SpecialsKey = new List<KeyCode>()
    {   KeyCode.LeftShift, KeyCode.LeftControl, KeyCode.LeftAlt,
        KeyCode.RightShift, KeyCode.RightControl, KeyCode.RightAlt
    };
    public KeyCode Key1;
    public KeyCode SpecialKey;

    public InputRestrictions Restrictions;

    public Action(KeyCode _KC1, KeyCode _KC2, InputRestrictions _Restrictions)
    {
        Key1 = _KC1;
        SpecialKey = _KC2;
        Restrictions = _Restrictions;
    }

    public enum InputRestrictions
    {
        None,
        Simple,
        Combine,
        Both
    }
}

[System.Serializable]
public struct BannedInputs
{
    public List<KeyCode> AxisBanned;
    public List<KeyCode> ActionsBanned;
    public List<KeyCode> GlobalBanned;
}
