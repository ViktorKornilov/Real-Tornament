using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text ammoText;

    [Header("Components")]
    public Health health;
    public Weapon weapon;

    void Start()
    {
        UpdateUI();

        weapon.onShoot.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
        health.onDie.AddListener(Respawn);
    }

    void UpdateUI()
    {
        healthText.text = "HP" + health.health;
        ammoText.text = weapon.clipAmmo + "/" + weapon.ammo;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }

    void Respawn()
    {
        health.health = health.maxHealth;
        transform.position = Vector3.zero;
        UpdateUI();
    }
}