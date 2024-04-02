using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CustomGUIButton : CustomGUIControl
{
    public event UnityAction clik_Event;
    protected override void control_Off()
    {
        if (GUI.Button(CustomGUIPos.Rpos, content))
        {
            clik_Event?.Invoke();
        }
    }

    protected override void control_On()
    {
        if (GUI.Button(CustomGUIPos.Rpos, content,style))
        {
            clik_Event?.Invoke();
        }
    }
}
