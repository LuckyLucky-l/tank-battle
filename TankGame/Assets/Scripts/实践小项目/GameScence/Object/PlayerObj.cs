using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public Transform TankPK;//炮台位置
    public WeaponObj NowWeapon;//现在的武器
    public Transform WeaponPos;//武器位置

    public void changeWeapon(GameObject Weapon)
    {
        if (NowWeapon!=null)
        {
            Destroy(NowWeapon.gameObject);//动态删除现在的武器
        }
        GameObject RandomWeapon = Instantiate(Weapon,WeaponPos,false);//创建武器
        NowWeapon = RandomWeapon.GetComponent<WeaponObj>();//得到武器脚本
        NowWeapon.SetFaher(this);//将玩家设置为武器的父对象，然后通过武器传给子弹
    }
    private void Update()
    {
        //前进后退
        this.transform.Translate(moveSpeed*Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical"));
        //左右旋转
        this.transform.Rotate(roateSpeed * Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal"));
        //炮台旋转
        TankPK.transform.Rotate(roateSpeed * Vector3.up * Time.deltaTime * Input.GetAxis("Mouse X"));
        //开火
        if (Input.GetMouseButtonDown(0))//鼠标按下开火
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (NowWeapon!=null)
        {
            NowWeapon.fire();
        }
       
    }
    public override void Dead()
    {
        //base.Dead();
        LoserPanel.Instance.ShowMe();

    }
    public override void Injurd(TankBaseObj obj)
    {
        base.Injurd(obj);
        GamePanel.Instance.AddHp(this.nowHp,this.maxHp);
    }
}
