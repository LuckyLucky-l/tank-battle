using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MyEnum
{
    Up,
    Down,
    Left,
    Right,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
    Center
}
[System.Serializable]
public class CustomGUIPos
{
    //外面只要调偏移，屏幕中心，控件中心，宽高
    public MyEnum cj= MyEnum.Center;//控件九宫格
    public MyEnum nine=MyEnum.Center;//屏幕九宫格
    private Rect rpos = new Rect(0, 0, 100, 100);//控件位置初始值
    public float width = 100;
    public float height = 100;
    public Vector2 v2;//偏移量
    private Vector2 centerpos;//控件中心点
    public void kj()//控件九宫格方法
    {
        switch (cj)//不同的对齐方法有不同的计算方法
        {
            case MyEnum.Up:
                centerpos.x = -width/2;
                centerpos.y = 0;
                break;
            case MyEnum.Down:
                centerpos.x = -width / 2;
                centerpos.y = -height;
                break;
            case MyEnum.Left:
                centerpos.x = 0;
                centerpos.y = -height/2;
                break;
            case MyEnum.Right:
                centerpos.x = -width;
                centerpos.y = -height/2;
                break;
            case MyEnum.Left_Up:
                centerpos.x = 0;
                centerpos.y = 0;
                break;
            case MyEnum.Left_Down:
                centerpos.x = 0;
                centerpos.y = -height;
                break;
            case MyEnum.Right_Up:
                centerpos.x = -width;
                centerpos.y = 0;
                break;
            case MyEnum.Right_Down:
                centerpos.x = -width;
                centerpos.y = -height;
                break;
            case MyEnum.Center:
                centerpos.x = -width / 2;
                centerpos.y = -height/2;
                break;
            default:
                break;
        }
    }
    public void pm()
    {
        switch (nine)
        {//公式：屏幕偏移+控件偏移+偏移量
            case MyEnum.Up:
                rpos.x = Screen.width/2 + centerpos.x + v2.x;
                rpos.y = 0 + centerpos.y + v2.y;
                break;
            case MyEnum.Down:
                rpos.x = Screen.width / 2 + centerpos.x + v2.x;
                rpos.y = Screen.height + centerpos.y + v2.y;
                break;
            case MyEnum.Left:
                rpos.x = 0 + centerpos.x + v2.x;
                rpos.y = Screen.height/2 + centerpos.y + v2.y;
                break;
            case MyEnum.Right:
                rpos.x = Screen.width + centerpos.x + v2.x;
                rpos.y = Screen.height/2 + centerpos.y + v2.y;
                break;
            case MyEnum.Left_Up:
                rpos.x = 0 + centerpos.x + v2.x;
                rpos.y = 0 + centerpos.y + v2.y;
                break;
            case MyEnum.Left_Down:
                rpos.x = 0 + centerpos.x + v2.x;
                rpos.y = Screen.height + centerpos.y + v2.y;
                break;
            case MyEnum.Right_Up:
                rpos.x = Screen.width + centerpos.x + v2.x;
                rpos.y = 0 + centerpos.y + v2.y;
                break;
            case MyEnum.Right_Down:
                rpos.x = Screen.width + centerpos.x + v2.x;
                rpos.y = Screen.height + centerpos.y + v2.y;
                break;
            case MyEnum.Center:
                rpos.x = Screen.width / 2 + centerpos.x + v2.x;
                rpos.y = Screen.height/2 + centerpos.y + v2.y;
                break;
            default:
                break;
        }
    }
    public Rect Rpos
    {
        get
        {
            kj();
            pm();
            rpos.width = width;
            rpos.height = height;
            return rpos;
        }
    }
}