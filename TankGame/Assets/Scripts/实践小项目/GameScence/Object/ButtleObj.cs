using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleObj : MonoBehaviour
{
    //子弹要干嘛，移动
    public float moveSpeed = 50;
    public GameObject boom;
    public TankBaseObj fatherObj;//无论是玩家几都是用的TankeObj当父类
    private void Update()
    {
        this.transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        
            //先判断是敌我双方，再判断，因为武器类也是TankBaseObj下的，不然就会碰到自己的武器就会受伤
            if (other.CompareTag("Cube") ||//比较tag的api
                other.CompareTag("Player") && fatherObj.CompareTag("Monster") ||//子弹的父对象是Monster炮塔，碰到的是玩家
                other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
            {
                TankBaseObj tank = other.GetComponent<TankBaseObj>();
                if (tank != null)//子弹接触到坦克基类下的玩家或者炮台才会受伤
                {
                    tank.Injurd(fatherObj);
                }
                Destroy(this.gameObject);
                GameObject obj = Instantiate(boom, this.transform.position, this.transform.rotation);
                AudioSource audioSource = obj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            }
        
        
        
    }
    public void SetFaher(TankBaseObj obj)//设置自己的父亲是谁，由父亲在外调用将自己传进来
    {
        fatherObj = obj;
    }
}
