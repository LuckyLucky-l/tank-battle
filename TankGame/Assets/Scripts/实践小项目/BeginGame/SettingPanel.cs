using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //获取控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;
    private void Start()
    {
        //监听
        sliderMusic.Slider_Event += (value) => GameDataMgr.Instance.changeMusicValue(value);
        //音乐大小
        sliderSound.Slider_Event += (value) => GameDataMgr.Instance.changeSoundValue(value);
        //音效大小
        togMusic.Toggle += (value) => GameDataMgr.Instance.openOrCloseMusic(value);
            //音乐开关
        togSound.Toggle += (value) => GameDataMgr.Instance.openOrCloseSound(value);
        //音效开关
        btnClose.clik_Event += () =>
        {
            Time.timeScale = 1;
            HideMe();
            if (SceneManager.GetActiveScene().name== "BeginScence")
            {
                BeginPanel.Instance.ShowMe();
            }
        };
        HideMe();
    }
    public void Update_Scence()
    {
       MusicData music= PlayerPrefsDataMgr.player.DataLoad(typeof(MusicData), "Music") as MusicData;
        togMusic.istoggle = music.isMusic;
        togSound.istoggle = music.isSound;
        sliderMusic.Rvalue= music.musicValue;
       sliderSound.Rvalue= music.soundValue;
        //更新面板信息
    }
    public override void ShowMe()
    {
        base.ShowMe();
        Update_Scence();
    }
}
