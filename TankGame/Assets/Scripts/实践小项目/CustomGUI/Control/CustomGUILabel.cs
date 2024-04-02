using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CustomGUILabel : CustomGUIControl
{
    protected override void control_Off()
    {
       GUI.Label(CustomGUIPos.Rpos, content);
        
    }

    protected override void control_On()
    {
        GUI.Label(CustomGUIPos.Rpos, content, style);
    }
}
