using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float speed = 20;
	public GameObject explosionPrefab;
	public GameObject hitPrefab;
	public int bounces;

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
			Instantiate(explosionPrefab,transform.position,transform.rotation);
		}
		else
		{
			transform.forward = other.contacts[0].normal;
		}

		if(!other.gameObject.CompareTag("Enemy"))
		{
			var obj = Instantiate(hitPrefab,transform.position,transform.rotation);
			obj.transform.forward = other.contacts[0].normal;
			obj.transform.position = other.contacts[0].point + transform.forward * -0.05f;
		}

		bounces--;

		var health = other.gameObject.GetComponent<Health>();
		if( health != null)
		{
			health.Damage(10);
		}
	}
}