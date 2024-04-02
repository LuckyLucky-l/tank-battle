using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginRotate : MonoBehaviour
{
    public float Rotate;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Rotate(Vector3.up,Rotate*Time.deltaTime);
    }
}
