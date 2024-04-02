using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponObj : MonoBehaviour
{
    //关联三个武器
    public GameObject[] Weapon;
    public GameObject Award;//奖励特效
    //碰到就删除自己
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameObject award = Instantiate(Award,this.transform.position, this.transform.rotation);
            AudioSource audioSource=award.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            
        }
       int index = Random.Range(0, Weapon.Length);
       GameObject obj = Weapon[index];
       PlayerObj playerObj= other.GetComponent<PlayerObj>();
        if (playerObj!=null)
        {
            playerObj.changeWeapon(obj);
        }
           
    }
}
