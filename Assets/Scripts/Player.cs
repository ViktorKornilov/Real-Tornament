using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;
	public Weapon weapon;
	public LayerMask weaponLayer;
	public GameObject equipText;

	void Start()
	{
		health = GetComponent<Health>();
	}


	void Update()
	{
		var cam = Camera.main.transform;
		var collided = Physics.Raycast(cam.position, cam.forward,out var hit, 2f,weaponLayer);
		equipText.SetActive(collided);

		if (collided)
		{
			weapon = hit.transform.GetComponent<Weapon>();
		}

		if (collided && Input.GetKeyDown(KeyCode.E))
		{
			weapon = hit.transform.GetComponent<Weapon>();
		}


		if (weapon == null) return;

		// manual mode
		if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			weapon.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			weapon.onRightClick.Invoke();
		}

		// auto mode
		if(weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			weapon.Shoot();
		}

		if( Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
		{
			weapon.Reload();
		}


	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			health.Damage(10);
		}
	}
}