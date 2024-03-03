using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
	     animator.Play("zombie_walk_forward");
        agent = GetComponent<NavMeshAgent>();
        if(target == null)target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
         agent.destination = target.position;
    }
}