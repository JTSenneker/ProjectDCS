﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

using UnityStandardAssets.Characters.FirstPerson;

public enum ShootType {
    PROJECTILE,
    RAYCAST
}

public class Weapon : MonoBehaviour
{
    public ShootType shootType;
    public GameObject projectile;
    public Transform projectileSpawnpoint;
    //public FirstPersonController fpc;
    //public PlayerManager pm;
    private Player playerIn;
    //public List<FirstPersonController> players = new List<FirstPersonController>();

    public int controllerId = 0;

    // Start is called before the first frame update
    void Start()
    {
        FirstPersonController player = gameObject.GetComponent<FirstPersonController>();
        playerIn = ReInput.players.GetPlayer(player.controllerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn.GetButton("Shoot")) {
            if (shootType == ShootType.PROJECTILE) {
                // Inst.
                Instantiate(projectile, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            } else {
                // Raycast
            }
        }
    }
}
