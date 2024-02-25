using TMPro;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Weapon weapon;
    public TMP_Text ammoText;

    void Start()
    {
        weapon.onShoot.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        ammoText.text = weapon.ammo.ToString();
    }
}