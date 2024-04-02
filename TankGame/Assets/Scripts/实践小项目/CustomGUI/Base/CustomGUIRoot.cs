using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] CustomGUIControl;
    void Start()
    {
        CustomGUIControl = this.GetComponentsInChildren<CustomGUIControl>();
    }
    private void OnGUI()
    {
        //if (!Application.isPlaying)//避免浪费性能，所以只有在不运行时，也就是编辑模式下才动态添加子对象
        //{
        CustomGUIControl = this.GetComponentsInChildren<CustomGUIControl>();
        //}

        for (int i = 0; i < CustomGUIControl.Length; i++)
        {
            CustomGUIControl[i].DrawGUI();
        }
    }
}
