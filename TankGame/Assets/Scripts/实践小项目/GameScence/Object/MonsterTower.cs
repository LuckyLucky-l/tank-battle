using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //子弹
    public GameObject buttle;
    //开火位置
    public Transform[] firePos;
    //开火间隔时间
    public float time = 1;
    //现在的时间,用于记录现在的时间
    public float nowtime=0;

    public override void Fire()
    {
        for (int i = 0; i < firePos.Length; i++)
            {
              GameObject gameObject=Instantiate(buttle, firePos[i].position, firePos[i].rotation);
              ButtleObj tankBaseObj = gameObject.GetComponent<ButtleObj>();
              tankBaseObj.SetFaher(this);
            }
    }

    private void Update()
    {
        nowtime += Time.deltaTime;
        if (nowtime>=time)
        {
            Fire();
            nowtime = 0;
        }
    }
    public override void Injurd(TankBaseObj obj)
    {
        //不会受伤
    }
}
