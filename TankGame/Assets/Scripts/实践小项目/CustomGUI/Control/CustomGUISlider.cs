using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum SliderStyle
{
    Horizontal,
    Vertical
}
public class CustomGUISlider : CustomGUIControl
{
    public SliderStyle Slider = SliderStyle.Horizontal;
    public float Rvalue=1;
    public float Minvalue=0;
    public float Maxvalue=1;
    public GUIStyle sliderStyle;
    public event UnityAction<float> Slider_Event;
    private float old_Slider_Event;
    protected override void control_Off()
    {
        switch (Slider)
        {
            case SliderStyle.Horizontal:
                Rvalue= GUI.HorizontalSlider(CustomGUIPos.Rpos, Rvalue, Minvalue, Maxvalue);
                if (Rvalue!=old_Slider_Event)
                {
                    Slider_Event?.Invoke(Rvalue);
                    old_Slider_Event = Rvalue;
                }
                break;
            case SliderStyle.Vertical:
                Rvalue=GUI.VerticalSlider(CustomGUIPos.Rpos, Rvalue, Minvalue, Maxvalue);
                if (Rvalue != old_Slider_Event)
                {
                    Slider_Event?.Invoke(Rvalue);
                    old_Slider_Event = Rvalue;
                }
                break;
        }
    }

    protected override void control_On()
    {
        switch (Slider)
        {
            case SliderStyle.Horizontal:
                Rvalue= GUI.HorizontalSlider(CustomGUIPos.Rpos, Rvalue, Minvalue, Maxvalue,style,sliderStyle);
                if (Rvalue != old_Slider_Event)
                {
                    Slider_Event?.Invoke(Rvalue);
                    old_Slider_Event = Rvalue;
                }
                break;
                break;
            case SliderStyle.Vertical:
                Rvalue= GUI.VerticalSlider(CustomGUIPos.Rpos, Rvalue, Minvalue, Maxvalue,style,sliderStyle);
                if (Rvalue != old_Slider_Event)
                {
                    Slider_Event?.Invoke(Rvalue);
                    old_Slider_Event = Rvalue;
                }
                break;
                break;
            default:
                break;
        }
    }
}
