using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    private bool hover = false;
    public bool Hover
    { 
        get { return hover; } 
        set { SetReset(ref hover, value, settedHover, resettedHover); } 
    }
    private bool pressed = false;
    public bool Pressed
    {
        get { return pressed; }
        set { SetReset(ref pressed, value, settedPressed, settedRelesed); }
    }
    public delegate void SetResetDelegate(bool value);
    public bool toggle = false;

    void SetReset(ref bool prev, bool value, EventHandler setted, EventHandler resetted)
    {
        if (!prev && value && setted != null)
        {
            prev = value;
            setted(this, null);
        }
        else if (prev && !value && resetted != null)
        {
            prev = value;
            resetted(this, null);
        }
    }

    public event EventHandler settedHover;
    public event EventHandler resettedHover;
    public event EventHandler settedPressed;
    public event EventHandler settedRelesed;

    void Update()
    {
        if(toggle)
        {
            if (hover && Input.GetMouseButtonDown(0))
            {
                Pressed = !pressed;
            }
        }
        else
        {
            if (!hover)
                pressed = false;
            if (!Input.GetMouseButton(0))
            {
                Pressed = false;
            }
            if (hover && Input.GetMouseButtonDown(0))
            {
                Pressed = true;
            }
        }
    }
}
