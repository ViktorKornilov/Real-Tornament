
using UnityEngine;

public class GrenadeMod : MonoBehaviour
{

    public Weapon weapon;
    public GameObject grenade;
    public GameObject originalBullet;





    void Awake()
    {
        originalBullet = weapon.bulletPrefab;
    }
    //asign this as event
    public void UnderbarrelGrenadeLauncher()
    {
        weapon.bulletPrefab = grenade;
        weapon.Shoot();
        weapon.bulletPrefab = originalBullet;
    }

}