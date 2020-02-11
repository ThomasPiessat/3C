using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public delegate void MouseEventHandler(float _XValue, float _YValue, float _MouseWheel);
    public static event MouseEventHandler OnMouse;

    public delegate void LeftMouseButtonPressed();
    public static event LeftMouseButtonPressed OnMouseLeftButtonPressed;



    public static void TriggerLeftMouseButtonPressed()
    {
        if (OnMouseLeftButtonPressed != null && Input.GetMouseButtonDown(0))
        {
            OnMouseLeftButtonPressed();
        }
    }

    public static void UpdateInput()
    {
        TriggerLeftMouseButtonPressed();
    }

}

