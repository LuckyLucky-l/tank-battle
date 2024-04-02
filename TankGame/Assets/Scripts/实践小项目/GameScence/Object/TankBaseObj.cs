using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int Atk;
    public int def;
    public int maxHp;
    public int nowHp;

    public float moveSpeed=10;
    public float roateSpeed=100;
    public float headRoateSpeed=100;
    public GameObject deadEff;//坦克死亡特效
    public abstract void Fire();//开火
    public virtual void Injurd(TankBaseObj obj)//受伤 里式替换原则，将子类对象传进来
    {
        int dmg = obj.Atk - this.def;
        if (dmg<0)//攻击力小于防御力
        {
            return;
        }
        if (dmg>0)//攻击力大于防御力
        {
            this.nowHp -= dmg;
            if (nowHp<=0)//血量小于等于0应该死亡
            {
                this.nowHp = 0;
                Dead(); 
            }
        }
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
        if (deadEff!=null)
        {
            //创建实例化对象
            GameObject gameObject = Instantiate(deadEff,this.transform.position,this.transform.rotation);
            GamePanel.Instance.Update_score(10);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            audioSource.Play();
        }
    }
}
