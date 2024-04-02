using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUIControl
{
    //图片绘制的缩放模式
    public ScaleMode scaleMode;
    protected override void control_Off()
    {
        GUI.DrawTexture(CustomGUIPos.Rpos, content.image,scaleMode);
    }

    protected override void control_On()
    {
        GUI.DrawTexture(CustomGUIPos.Rpos, content.image,scaleMode);
    }
}
