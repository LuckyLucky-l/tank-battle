using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum control
{
    On,
    Off
}
public abstract class CustomGUIControl : MonoBehaviour
{
    public CustomGUIPos CustomGUIPos;

    public control control = control.Off;
    public GUIStyle style;
    public GUIContent content;
    public void DrawGUI()
    {
        switch (control)
        {
            case control.On:
                control_On();
                break;
            case control.Off:
                control_Off();
                break;
        }
    }
    protected abstract void control_On();
    protected abstract void control_Off();
}
