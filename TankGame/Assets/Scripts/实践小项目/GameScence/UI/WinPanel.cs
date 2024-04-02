using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    //关联组件
    public CustomGUIInput inputName;
    public CustomGUIButton btnSure;
    private void Start()
    {
        btnSure.clik_Event += () =>
        { 
            GameDataMgr.Instance.AddRankData(inputName.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowtime);
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScence");
        };
      HideMe();
    }
}
