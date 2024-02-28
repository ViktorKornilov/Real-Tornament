using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public Transform target;
	NavMeshAgent agent;
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		if(target == null) target = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		agent.destination = target.position;
	}
}