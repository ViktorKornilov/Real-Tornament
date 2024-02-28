using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public UnityEvent onShoot;
	public UnityEvent<bool> onReload;
	public UnityEvent<bool> onSpecial;

	public GameObject bulletPrefab;
	public GameObject shootEffect;

	public int ammo;
	public int maxAmmo = 10;
	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public float recoilAngle = 5f;
	public float pelletsCount = 1;

	void Update()
	{
		fireCooldown -= Time.deltaTime;
	}

	public async void Shoot()
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

		for(int i = 0;i < pelletsCount; i++)
		{
			var bullet = Instantiate(bulletPrefab,shootEffect.transform.position,transform.rotation);
			var xOffset = Random.Range(-recoilAngle, recoilAngle);
			var yOffset = Random.Range(-recoilAngle, recoilAngle);
			bullet.transform.eulerAngles += new Vector3(xOffset,yOffset,0);
		}

		onShoot.Invoke();

		shootEffect.SetActive(true);
		await new WaitForSeconds(0.03f);
		shootEffect.SetActive(false);
	}


	public async void Reload()
	{
		if (isReloading) return;
		isReloading = true;
		onReload.Invoke(false);

		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
		print ("Reloaded");
		onReload.Invoke(true);
	}
}