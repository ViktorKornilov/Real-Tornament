using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;

	void Start()
	{
		health = GetComponent<Health>();
		health.onDie.AddListener(Die);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			health.Damage(10);
		}
	}

	void Die()
	{
		transform.position = Vector3.zero;
		health.health = health.maxHealth;
	}
}