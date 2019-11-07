using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputExtension
{
    public static KeyCode GetKeyDown()
    {
        foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(kc))
            {
                return kc;
            }
        }
        return KeyCode.None;
    }

    public static KeyCode GetKeyUp()
    {
        foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kc))
            {
                return kc;
            }
        }
        return KeyCode.None;
    }

    public static KeyCode GetKeyHold()
    {
        foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kc))
            {
                return kc;
            }
        }
        return KeyCode.None;

    }

}
