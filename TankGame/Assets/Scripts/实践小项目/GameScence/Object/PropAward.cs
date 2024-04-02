using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyPropAward
{
     Attack,
     defense,
     MaxHp,
     Hp
}
public class PropAward : MonoBehaviour //属性奖励对象
{
    public MyPropAward type = MyPropAward.Attack;//枚举的初始化，初始值为attack,
                                                 //如果没有后面的会默认可能是枚举第一个
    public GameObject Effect;//特效
    public int ChangeValueAttack=10;
    public int ChangeValueDefence=10;
    public int ChangeValueMaxHp=100;
    public int ChangeValueHp=10;
    private void OnTriggerEnter(Collider other)
    {
        //得到脚本
       PlayerObj player= other.GetComponent<PlayerObj>();
       if (player != null)//因为如果没加这个前提条件，当子弹碰到属性的时候也是触发了，这时候得到的player就为空，下面就会引用报错
        {
            switch (type)
            {
                case MyPropAward.Attack:
                    player.Atk += ChangeValueAttack;
                    break;
                case MyPropAward.defense:
                    player.def += ChangeValueDefence;
                    break;
                case MyPropAward.MaxHp:
                    player.nowHp += ChangeValueMaxHp;
                    if (player.nowHp>ChangeValueMaxHp)
                    {
                        player.nowHp = player.maxHp;
                    }
                    GamePanel.Instance.AddMaxHp(player.nowHp);
                    break;
                case MyPropAward.Hp:
                    player.nowHp += ChangeValueHp;
                    if (player.nowHp > player.maxHp)
                    {
                        player.nowHp = player.maxHp;
                    }
                    GamePanel.Instance.AddHp(player.nowHp, player.maxHp);
                    break;
            }
            if (Effect != null)
            {
                GameObject Eff = Instantiate(Effect, this.transform.position, this.transform.rotation);
                AudioSource audioSource = Eff.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            }
            Destroy(this.gameObject);
        }
        
    }
}
