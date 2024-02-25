using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text healthText;
    public Health health;
    public TMP_Text ammoText;
    public Weapon weapon;

    void Start()
    {
        UpdateUI();
        health.onDamage.AddListener(UpdateUI);
        weapon.onShoot.AddListener(UpdateUI);
        weapon.onReload.AddListener((ended) => UpdateUI());
    }


    void UpdateUI()
    {
        healthText.text = health.health.ToString();
        ammoText.text = weapon.ammo.ToString();
    }
}