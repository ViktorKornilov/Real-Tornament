using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;

	void Start()
	{
		health = GetComponent<Health>();
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			health.Damage(10);
		}
	}
}