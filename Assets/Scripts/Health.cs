using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    public UnityEvent onDamage;
    public UnityEvent onDie;

    void Start()
    {
        if(health == 0) health = maxHealth;
    }


    public void Damage(int damage)
    {
        health -= damage;
        onDamage.Invoke();
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDie.Invoke();
        Destroy(gameObject);
    }
}