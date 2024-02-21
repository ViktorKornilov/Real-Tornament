using UnityEngine;

public class ShotgunMode : MonoBehaviour
{
    public Weapon weapon;
    public bool activated;

    public void SwitchMode()
    {
        activated = !activated;
        weapon.bulletsPerShot = activated ? 5 : 1;
    }


    public void Burst()
    {
        weapon.fireInterval = 0;
        weapon.Shoot();
        weapon.Shoot();
        weapon.Shoot();
        weapon.Shoot();
        weapon.fireInterval = 0.1f;
    }
}