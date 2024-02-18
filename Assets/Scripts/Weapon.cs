using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    float fireCooldown;
    public float reloadTime = 2;

    void Update()
    {
        // manual shooting
        if (!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        // automatic shooting
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        if(isReloading) return;
        if (ammo <= 0)
        {
            Reload();
            return;
        }
        if(fireCooldown > 0) return;

        ammo--;
        fireCooldown = fireInterval;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    async void Reload()
    {
        if (ammo == maxAmmo) return;
        if(isReloading) return;

        isReloading = true;

        print ("Reloading...");
        await new WaitForSeconds(reloadTime);
        print("Reloaded!");

        isReloading = false;
        ammo = maxAmmo;
    }
}