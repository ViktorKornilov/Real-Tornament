using UnityEngine;

public class Rocket : MonoBehaviour
{
	public GameObject explosionPrefab;
	public GameObject hitPrefab;

	public float speed = 20;
	public float bounces = 0;

	void Start()
	{
		Destroy(gameObject,3f);
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision other)
	{
		if (bounces == 0)
		{
			Destroy(gameObject);
			if(explosionPrefab)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}
		else
		{
			transform.forward = other.contacts[0].normal;
		}
		bounces--;

		if (!other.gameObject.CompareTag("Enemy"))
		{
			var obj = Instantiate(hitPrefab, transform.position, Quaternion.identity);
			obj.transform.forward = other.contacts[0].normal;
			obj.transform.position += obj.transform.forward * 0.15f;
		}

		var health = other.gameObject.GetComponent<Health>();
		if( health != null)
		{
			health.Damage(10);
		}
	}
}