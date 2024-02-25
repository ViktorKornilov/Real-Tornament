using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public FirstPersonLook camera;
    public bool isScoped;
    public void Scoping()
    {
        isScoped = !isScoped;
        var cam = camera.GetComponent<Camera>();
        if (isScoped)
        {
            cam.fieldOfView = 40;
        }
        else
        {
            cam.fieldOfView = 60;
        }
    }
}
