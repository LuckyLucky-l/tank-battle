using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : TankBaseObj
{
    //随机移动点
    public Transform[] randomPos;
    //目标点
    public Transform target;
    //炮塔始终朝向位置
    public Transform Player;
    public Transform tower;//炮塔
    public Transform buttlePos;//子弹发射位置
    public GameObject buttle;//关联子弹
    public float time=1;//间隔时间
    public float nowtime = 0;//现在的时间
    public float fireDis = 20;//攻击范围

    public Texture HpBK;//背景图片
    public Texture Hp;//血量图片
    private Rect texturePosBk;//背景图片坐标
    public Rect texturePos;
    public float timeHp;
    private void Update()
    {
        //朝向目标点
        transform.LookAt(target);
        //移动
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        tower.LookAt(Player);
        if (Vector3.Distance(this.transform.position, target.position) < 0.05f)//判断与目的地的距离
        {
            //重新随机目标点
            RandomPos();
        }
        if (Vector3.Distance(this.transform.position,Player.position)<=fireDis)
        {
            nowtime += Time.deltaTime;
             if (nowtime >= time)
             {
              nowtime = 0;
              Fire();
             }
        }
        
    }
    public void RandomPos()
    {
        target = randomPos[Random.Range(0,randomPos.Length)];
    }
    public override void Fire()
    {
      GameObject obj= Instantiate(buttle,buttlePos.transform.position,buttlePos.transform.rotation);
      ButtleObj buttleObj=  obj.GetComponent<ButtleObj>();
      buttleObj.SetFaher(this);
    }
    private void OnGUI()
    {
        if (timeHp>0)
        {
            timeHp -= Time.deltaTime;
            //绘制血条
            //世界坐标转换成屏幕坐标
            Vector3 vector3 = Camera.main.WorldToScreenPoint(this.transform.position);//主摄像头看到的物体世界坐标转换成物体本身坐标
                                                                                      //，所以物体z轴方向就是面朝主摄像头的
                                                                                      //怎么获得z轴方向的距离呢
            //屏幕坐标转换成gui坐标
            vector3.y = Screen.height - vector3.y;
            texturePosBk.x = vector3.x - 50;
            texturePosBk.y = vector3.y - 30;
            texturePosBk.width = 100;
            texturePosBk.height = 15;
            GUI.DrawTexture(texturePosBk, HpBK);

            texturePos.x = vector3.x - 50;
            texturePos.y = vector3.y - 30;
            texturePos.width = (float)nowHp / maxHp * 100;
            texturePos.height = 10;
            GUI.DrawTexture(texturePos, Hp);
        }
    }
        
    //设置显示时间 只有受伤3秒后才会显示
    public override void Injurd(TankBaseObj obj)
    {
        base.Injurd(obj);
        timeHp = 3;
    }
}
