using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum sClass { tank, medic, sniper, joat };
public class Class_Stats_Final : MonoBehaviour {
    public float maxHealth;
    public float maxArmor;
    public float moveSpeed;
    public float sprintSpeed;
    public float currentHealth { get; set; }
    private float currentArmor;
    public float ADS;
    public float abilityCooldown;

    public sClass job;

    public GameObject abilityObject;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UseAbility();
        }
    }

    void UseAbility()
    {
        switch (job)
        {
            case sClass.joat:
                GameObject waterBalloon = Instantiate(abilityObject, spawnPoint.position, Quaternion.identity);
                waterBalloon.GetComponent<Rigidbody>().AddForceAtPosition(spawnPoint.forward * 500, transform.position);
                break;
            case sClass.medic:
                //develop MEDIC ability
                break;
            case sClass.tank:
                //develop TANK ability
                break;
            case sClass.sniper:
                //develop SNIPER ability
                break;

            //raycast and timer for lockpick
        }
    }
}
