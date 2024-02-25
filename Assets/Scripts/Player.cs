using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Health health;

    void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("Enemy"))
         {
               health.Damage(20);
         }
    }
}