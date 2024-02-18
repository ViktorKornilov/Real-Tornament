using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float speed = 20;

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
		Destroy(gameObject);

		var health = other.gameObject.GetComponent<Health>();
		if( health != null)
		{
			health.Damage(10);
		}
	}
}