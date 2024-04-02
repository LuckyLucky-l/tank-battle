using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这里传泛型主要原因是为了得到其他面板的脚本
public class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instance;
    public static T Instance => instance;
    private void Awake()
    {
        instance = this as T;
    }
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
