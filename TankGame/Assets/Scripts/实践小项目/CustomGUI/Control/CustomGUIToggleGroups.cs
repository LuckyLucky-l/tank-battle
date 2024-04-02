using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroups:MonoBehaviour
{
    public CustomGUIToggle[] gUIToggle;
    private CustomGUIToggle oldgUIToggle;
    private void Start()
    {
        if (gUIToggle.Length==0)
        {
            return;
        }
        for (int i = 0; i < gUIToggle.Length; i++)
        {
            CustomGUIToggle custom = gUIToggle[i];
            custom.Toggle += (vaule) =>
            {
                if (vaule)
                {
                    for (int j = 0; j < gUIToggle.Length; j++)
                    {
                        if (custom != gUIToggle[j])
                        {
                            gUIToggle[j].istoggle = false;
                        }
                    }
                    oldgUIToggle = custom;
                }
                else if (custom == oldgUIToggle)
                {
                    custom.istoggle = true;
                }
            };
        }
    }
}
