using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public int ammo;
	public int maxAmmo = 10;
	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;

	void Update()
	{
		// manual mode
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}

		// auto mode
		if(isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

		if( Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
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
		Instantiate(bulletPrefab,transform.position,transform.rotation);
	}


	async void Reload()
	{
		if (isReloading) return;
		isReloading = true;

		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
		print ("Reloaded");
	}
}