using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Health health;


    void Update()
    {

	    if(weapon == null)return;

	    if (Input.GetKeyDown(KeyCode.Mouse1))
	    {
		    weapon.onRightClick.Invoke();
	    }

	    // manual shooting
	    if (!weapon.isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
	    {
		    weapon.Shoot();
	    }
	    // automatic shooting
	    if (weapon.isAutomatic && Input.GetKey(KeyCode.Mouse0))
	    {
		    weapon.Shoot();
	    }

	    if (Input.GetKeyDown(KeyCode.R))
	    {
		    weapon.Reload();
	    }
    }

    void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("Enemy"))
         {
               health.Damage(20);
         }
    }
}