using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitPanel : BasePanel<QuitPanel>
{
    //获得控件
    public CustomGUIButton btnClose;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnContinue;
    //事件监听
    private void Start()
    {
        btnClose.clik_Event += () =>
        {
            HideMe();
            Time.timeScale = 1;
        };
        btnQuit.clik_Event += () =>
        {
            SceneManager.LoadScene("BeginScence");
        };
        btnContinue.clik_Event += () =>
        {
            HideMe();
            Time.timeScale = 1;
        };
        HideMe();
    }
}
