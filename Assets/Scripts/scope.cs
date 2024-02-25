using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope : MonoBehaviour
{
    public FirstPersonLook view;
    public int FOV = 40;
    public bool isscoped;
    
    public void scoped()
    {
        isscoped = !isscoped;
        var cam = view.GetComponent<Camera>();
        if(isscoped)
        {
            cam.fieldOfView = FOV;
        }
        else
        {
            cam.fieldOfView = 60;
        }

    }
}

