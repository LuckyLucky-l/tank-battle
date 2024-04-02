using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CustomGUIInput : CustomGUIControl
{
    //public event UnityAction<string> textChange;

    //private string oldStr = "";
    //protected override void control_Off()
    //{
    //    content.text = GUI.TextField(CustomGUIPos.Rpos, content.text);
    //    //if (oldStr != content.text)
    //    //{
    //    //    textChange?.Invoke(oldStr);
    //    //    oldStr = content.text;
    //    //}
    //}

    //protected override void control_On()
    //{
    //    content.text = GUI.TextField(CustomGUIPos.Rpos, content.text, style);
    //    //if (oldStr != content.text)
    //    //{
    //    //    textChange?.Invoke(oldStr);
    //    //    oldStr = content.text;
    //    //}
    //}
    public event UnityAction<string> textChange;

    private string oldStr = "";
    protected override void control_Off()
    {
        content.text = GUI.TextField(CustomGUIPos.Rpos, content.text);
        if (oldStr != content.text)
        {
            textChange?.Invoke(oldStr);
            oldStr = content.text;
        }
    }

    protected override void control_On()
    {
        content.text = GUI.TextField(CustomGUIPos.Rpos, content.text, style);
        if (oldStr != content.text)
        {
            textChange?.Invoke(oldStr);
            oldStr = content.text;
        }
    }
}
