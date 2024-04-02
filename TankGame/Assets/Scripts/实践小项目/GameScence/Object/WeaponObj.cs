using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject buttle;//子弹
    public Transform[] shoot;//子弹发射位置
    public TankBaseObj fatherObj;//无论是什么武器都是用的TankeObj当父类
    //武器发射
    public void fire()
    {
        for (int i=0;i<shoot.Length;i++)
        {
            GameObject obj= Instantiate(buttle,shoot[i].position,shoot[i].rotation);//创建子弹对象
            ButtleObj buttle2 = obj.GetComponent<ButtleObj>();//得到子弹脚本
            buttle2.SetFaher(fatherObj);//调用子弹脚本设置父亲方法将自己传进去
        }
        
    }
    public void SetFaher(TankBaseObj obj)//设置自己的父亲是谁，由父亲在外调用将自己传进来
    {
        fatherObj = obj;
    }
    
}
