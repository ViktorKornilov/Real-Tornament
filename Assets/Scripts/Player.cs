using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text ammoText;

    [Header("Components")]
    public Health health;
    public Weapon weapon;
    public LayerMask weaponLayer;
    public GameObject grabText;

    void Start()
    {
        UpdateUI();

        //weapon.onShoot.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
        health.onDie.AddListener(Respawn);
    }

    void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit,2f,weaponLayer);
        grabText.SetActive(collided);
        if (collided)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                weapon = hit.transform.GetComponent<Weapon>();
            }
        }

        // manual mode
        if (weapon == null) return;

        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        // auto mode
        if(weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if( Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }

        if( Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }

    }

    void UpdateUI()
    {
        healthText.text = "HP" + health.health;
        //ammoText.text = weapon.clipAmmo + "/" + weapon.ammo;
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