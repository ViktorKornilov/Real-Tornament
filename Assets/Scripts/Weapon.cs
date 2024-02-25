using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public UnityEvent onRightClick;
	public UnityEvent onShoot;
	public UnityEvent<bool> onReload;

	public GameObject bulletPrefab;
	public int ammo;
	public int maxAmmo = 10;
	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public float recoilAngle;
	public int bulletsPerShot = 1;
	void Update()
	{
		// manual mode
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			onRightClick.Invoke();
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

	public void Shoot()
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
		onShoot.Invoke();

		for (int i = 0; i < bulletsPerShot; i++)
		{
			var bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
			var offsetX = Random.Range(-recoilAngle,recoilAngle);
			var offsetY = Random.Range(-recoilAngle,recoilAngle);
			bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
		}
	}


	async void Reload()
	{
		if (isReloading) return;
		isReloading = true;
		onReload.Invoke(false);
		await new WaitForSeconds(1f);

		ammo = maxAmmo;
		isReloading = false;
		onReload.Invoke(true);
		print ("Reloaded");
	}
}