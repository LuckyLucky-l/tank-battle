using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string name;
    private void OnGUI()
    {
        name=GUI.TextField(new Rect(0, 0, 100, 100), name);
    }
}
