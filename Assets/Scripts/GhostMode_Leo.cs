using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
    public Weapon weapon;
    public GameObject player;
    public MeshRenderer playerBody;

    public bool activated;

    public bool isCoolDown = false;
    public float coolDownTime = 10;

    public int skillDuration = 5;
    public float speedBoost = 2;
    public float jumpBoost = 2;

    public float transparencyBoost = 0.7f;

    Jump playerJump;
    FirstPersonMovement playerMove;
    private void Start()
    {
        playerJump = player.GetComponent<Jump>();
        playerMove = player.GetComponent<FirstPersonMovement>();
    }
    public void ghostActivate()
    {
        // Function to add to On Right Click()
        if (!activated && !isCoolDown)
        {
            activated = true;
            ghostTransform();
        }
    }

    public async void ghostTransform()
    {
        // To make it work, change "Surface Type" of player material to "Transparent"
        playerBody.material.color -= new UnityEngine.Color(0, 0, 0, transparencyBoost);

        playerJump.jumpStrength *= jumpBoost;
        playerMove.speed *= speedBoost;
        playerMove.runSpeed *= speedBoost;

        weapon.enabled = false;
        weapon.gameObject.transform.localPosition -= new Vector3(0, 1000, 0);


        await new WaitForSeconds(skillDuration);
        ghostDetransform();
    }

    public void ghostDetransform()
    {
        // To make it work, change "Surface Type" of player material to "Transparent"
        playerBody.material.color += new UnityEngine.Color(0, 0, 0, transparencyBoost);

        playerJump.jumpStrength /= jumpBoost;
        playerMove.speed /= speedBoost;
        playerMove.runSpeed /= speedBoost;

        weapon.enabled = true;
        weapon.gameObject.transform.localPosition += new Vector3(0, 1000, 0);


        activated = false;
        GhostCoolDown();
    }

    public async void GhostCoolDown()
    {
        isCoolDown = true;
        await new WaitForSeconds(coolDownTime);
        isCoolDown = false;
    }
}
