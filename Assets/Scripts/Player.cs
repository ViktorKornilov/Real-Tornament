using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;
	public TMP_Text healthText;

	void Start()
	{
		UpdateUI(100);
		health = GetComponent<Health>();

		health.onDie.AddListener(Die);
		health.onDamage.AddListener(UpdateUI);
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

	void UpdateUI(int hp)
	{
		healthText.text = hp.ToString();
	}
}