using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;

    public UnityEvent onDie;
    public UnityEvent onDamage;

    void Start()
    {
        if(hp == 0)hp = maxHp;
    }

    public void Damage(int damage)
    {
        hp -= damage;
        onDamage.Invoke();
        if(hp <= 0)
        {
            Die();
            onDie.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}