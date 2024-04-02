using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCube : MonoBehaviour //可击毁箱子
{
    public GameObject[] weapon;//随机武器组
    public GameObject Eff;//死亡特效
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        int i = Random.Range(0,100);     
            if (i<50)//百分之五十的概率触发奖励
            {
            int j = Random.Range(0,weapon.Length);
            Instantiate(weapon[j],this.transform.position,this.transform.rotation);
            }
       GameObject Ef= Instantiate(Eff, this.transform.position, this.transform.rotation);
        AudioSource audioSource= Ef.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
    }

}
