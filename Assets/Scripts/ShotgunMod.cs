using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMod : MonoBehaviour
{
    public Weapon weapon;
    bool activated;

    void Start()
    {
        weapon.onSpecial.AddListener(OnSpecial);
    }


    public void OnSpecial(bool started)
    {
        if(started)activated = !activated;

        if (activated)
        {
            weapon.pelletsCount = 5;
        }
        else
        {
            weapon.pelletsCount = 1;
        }
    }
}