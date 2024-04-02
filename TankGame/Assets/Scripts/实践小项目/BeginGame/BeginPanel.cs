using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    private void Start()
    {
        btnBegin.clik_Event += () =>
        {
            //开始界面
            SceneManager.LoadScene("GameScence");
        };
        btnSetting.clik_Event += () =>
        {
            //设置界面
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clik_Event += () =>
        {
            //退出界面
            Application.Quit();
        };
        btnRank.clik_Event += () =>
        {
            //排行榜界面s
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }
}
