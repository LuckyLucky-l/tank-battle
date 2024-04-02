using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//只用来控制背景音乐
public class BkMusic : MonoBehaviour
{
    private static BkMusic instance;
    public static BkMusic Instance => instance;
    public AudioSource audioSource;//要关联一个背景音乐，不然后面实例化会报空
    private void Awake()
    {
        instance = this;//每次激活就会实例化
        audioSource.volume = GameDataMgr.Instance.musicData.musicValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isMusic;
    }
    public void ChangeMusicValue(float value)
    {
        audioSource.volume = value;
    }
    public void openOrcloseMusic(bool value)
    {
        audioSource.mute = !value;
    }
}
