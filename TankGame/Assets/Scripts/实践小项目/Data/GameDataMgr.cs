using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;
    public MusicData musicData;
    public RankList rankdata;
    
    //第一次音乐设置
    public GameDataMgr()
    {   

        musicData = PlayerPrefsDataMgr.player.DataLoad(typeof(MusicData), "Music") as MusicData;
        if (!musicData.isFirst)
        {
            musicData.isMusic = true;
            musicData.isSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            musicData.isFirst = true;
            PlayerPrefsDataMgr.player.DataSave(musicData, "Music");
        }
        rankdata = PlayerPrefsDataMgr.player.DataLoad(typeof(RankList), "Rank") as RankList;
    }
    public void AddRankData(string name,int score,float time)//存排行榜
    {

        rankdata.list.Add(new RankInfo(name, score, time));
        //排序
        rankdata.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        //排序过后 移除10条以外的数据
        //从尾部往前遍历 移除每一条
        for (int i = rankdata.list.Count - 1; i >= 10; i--)
        {
            rankdata.list.RemoveAt(i);
        }
        //存储
        PlayerPrefsDataMgr.player.DataSave(rankdata, "Rank");
    }
    public void openOrCloseMusic(bool value)
    {
        musicData.isMusic = value;
        BkMusic.Instance.openOrcloseMusic(value);
        PlayerPrefsDataMgr.player.DataSave(musicData, "Music");
    }
    public void openOrCloseSound(bool value)
    {
        musicData.isSound = value;
        PlayerPrefsDataMgr.player.DataSave(musicData, "Music");
    }
    public void changeMusicValue(float value)
    {
        musicData.musicValue = value;
        BkMusic.Instance.ChangeMusicValue(value);//背景音乐要播放一个音频，一直在场景上
        PlayerPrefsDataMgr.player.DataSave(musicData, "Music");
    }
    public void changeSoundValue(float value)
    {
        musicData.soundValue = value;//音效文件一般都是挂载到场景对象上的，死物或触碰才会播放
        PlayerPrefsDataMgr.player.DataSave(musicData, "Music");
    }
}
