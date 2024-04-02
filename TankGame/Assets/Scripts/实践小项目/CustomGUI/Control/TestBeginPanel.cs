using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBeginPanel : MonoBehaviour
{
    public CustomGUIButton btbegin;
    public CustomGUIButton btquit;
    public CustomGUIButton btclose;
    private void Start()
    {
        btbegin.clik_Event += () =>
        {
            Debug.Log("开始");
        };
        btclose.clik_Event += () =>
        {
            Debug.Log("结束");
        };
        btquit.clik_Event += () =>
        {
            Debug.Log("退出");
        };
    }
}
