using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMap : MonoBehaviour
{
    //小地图控件
    public Transform PlayerObj;
    private Vector3 pos;
    public float H=10;//控制小地图高度
    private void LateUpdate()
    {
        if (PlayerObj==null)
        {
            return;
        }
        //小地图
        pos.x = PlayerObj.position.x;
        pos.z = PlayerObj.position.z;
        pos.y = H;
        this.transform.position=pos;
    }
}
