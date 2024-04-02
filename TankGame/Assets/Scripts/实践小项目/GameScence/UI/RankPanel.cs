using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel :BasePanel<RankPanel>
{
    private List<CustomGUILabel> labName=new List<CustomGUILabel>();
    private List<CustomGUILabel> labScores=new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    public CustomGUIButton btnClose;
    public CustomGUIButton btnClear;
    private void Start()
    {
        btnClear.clik_Event += () =>
        {
            PlayerPrefs.DeleteAll();
            StartCoroutine(UpdateS());//延迟一帧
        };
       
        btnClose.clik_Event += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        for (int i = 1; i <=10; i++)//循环获取子对象脚本
        {
           labName.Add(this.transform.Find("Name/Name" + i).GetComponent<CustomGUILabel>());
           labScores.Add( this.transform.Find("scores/scores" + i).GetComponent<CustomGUILabel>());
           labTime.Add( this.transform.Find("Time/Time" + i ).GetComponent<CustomGUILabel>());
        }
        HideMe();
    }
    public IEnumerator UpdateS()//清空后更新面板
    {
        yield return null;
        Update_RankScence();
    }
    public void Update_RankScence()
    {

        //处理根据排行榜数据 更新面板
        //获取 GameDataMgr中的排行榜列表 用于在这里更新
        //得数据

        List<RankInfo> list = GameDataMgr.Instance.rankdata.list;
        //根据列表更新面板数据 
        for (int i = 0; i < list.Count; i++)
        {
            //Debug.Log($"{i}----{list[i].name}----{list[i].score.ToString()}");
            //名字
            labName[i].content.text = list[i].name;
            //分数
            labScores[i].content.text = list[i].score.ToString();
            //时间 存储的时间单位是s
            //把秒数 转换成 时  分 秒
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            //得到 几个小时
            // 8432s  60*60 = 3600
            //8432 / 3600 ≈ 2时
            if (time / 3600 > 0)
            {
                labTime[i].content.text += time / 3600 + "时";
            }
            //8432-7200 余 1232s
            // 1232s / 60 ≈ 20分  
            if (time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            //1232s-1200 余 32秒
            labTime[i].content.text += time % 60 + "秒";
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //PlayerPrefs.DeleteAll();
        Update_RankScence();
    }
}
