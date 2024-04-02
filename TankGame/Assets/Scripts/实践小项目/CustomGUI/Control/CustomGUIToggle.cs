using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CustomGUIToggle : CustomGUIControl
{
    public event UnityAction<bool> Toggle;
    public bool istoggle;
    private bool oldToggle;
    protected override void control_Off()
    {
        istoggle=GUI.Toggle(CustomGUIPos.Rpos, istoggle, content);
        if (istoggle!=oldToggle)
        {
                Toggle?.Invoke(istoggle);
                oldToggle = istoggle;
            //为什么要写oldToggle = istoggle?

            //oldToggle = istoggle;每次按下会监听，开关打开按下istoggle!=oldToggle，开始监听
            //2.然后关闭istoggle变成false,oldToggle还是false就不会监听，所以就直接取消了
            //3.然后再次按下，istoggle变成true,监听再次生效
            //所以监听只是实现了单选，没实现其中一个按钮一直是选中状态
        }

    }
    
    protected override void control_On()
    {
       istoggle= GUI.Toggle(CustomGUIPos.Rpos,istoggle , content,style);
        if (istoggle != oldToggle)
        {
            Toggle?.Invoke(istoggle);
            oldToggle = istoggle;
        }
    }
}
