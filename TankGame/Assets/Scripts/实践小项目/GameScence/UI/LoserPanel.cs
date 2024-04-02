using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserPanel : BasePanel<LoserPanel>
{
    public CustomGUIButton bunReturn;
    public CustomGUIButton continueChallenge;
    private void Start()
    {
        bunReturn.clik_Event += () =>
        {
            SceneManager.LoadScene("BeginScence");
        };
        continueChallenge.clik_Event += () =>
        {
            SceneManager.LoadScene("GameScence");
        };
        HideMe();
    }
}
