using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //获得控件
    public CustomGUILabel labGetScoresNumber;
    public CustomGUILabel labTime;
    public CustomGUITexture TextureHp;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    private float nowHp=0;
    [HideInInspector]
    public int nowScore = 0;
    private int time = 0;
    [HideInInspector]
    public float nowtime = 0;
    public float width = 240;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        btnSetting.clik_Event +=()=>
       {
           //设置界面
           SettingPanel.Instance.ShowMe();
           Time.timeScale = 0;
        };
        btnQuit.clik_Event += () =>
        {
            //退出界面
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
    }
    //更新时间
    public void Update()
    {
        nowtime +=Time.deltaTime;
        time = (int)nowtime;
        labTime.content.text = "";
        if (time/3600>0)//秒换成时分秒
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time%3600/60>0||labTime.content.text!="")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        else
            labTime.content.text += time % 60 + "秒";
    }
    //更新血量
    public void AddHp(int Hp,int MaxHp)
    {
        //血量=百分比=当前血量/最大血量*宽
        nowHp = (float)Hp / MaxHp * width;
        TextureHp.CustomGUIPos.width = nowHp;
    }
    public void AddMaxHp(int MaxHp)
    {
        nowHp = 240;
        TextureHp.CustomGUIPos.width = 240;
 ;
    }
    //跟新分数
    public void Update_score(int score)
    {
        nowScore += score;
        labGetScoresNumber.content.text = nowScore.ToString();
    }
}
