using TMPro;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Weapon weapon;
    public TMP_Text ammoText;
    public LayerMask weaponLayer;
    public float pickupRange = 2f;
    public GameObject pickText;
    public Transform hand;

    void Start()
    {
        //weapon.onShoot.AddListener(UpdateUI);
    }

    void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward,out var hit, pickupRange, weaponLayer);
        pickText.SetActive(collided);


        // EQUIPING
        if (weapon == null && collided && Input.GetKeyDown(KeyCode.E))
        {
            print("Equiped");
            weapon = hit.transform.GetComponent<Weapon>();
            hit.transform.GetComponent<Rigidbody>().isKinematic = true;

            hit.transform.position = hand.position;
            hit.transform.rotation = hand.rotation;
            hit.transform.SetParent(hand);
            return;
        }


        // UNEQUIPING
        if(weapon != null && Input.GetKeyDown(KeyCode.E))
        {
            print("Unequiped");
            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
            weapon.transform.SetParent(null);
            weapon = null;
            return;
        }



        if(weapon == null) return; // if no gun in hand, dont execute the rest of the code
        // manual mode
        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        // auto mode
        if(weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onSpecial.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            weapon.onSpecial.Invoke(false);
        }

        if( Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }
    }

    void UpdateUI()
    {
        ammoText.text = weapon.ammo.ToString();
    }
}