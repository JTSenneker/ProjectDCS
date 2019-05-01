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
    public float RaycastDistance;
    public float timeToUnlock;
    private float timer;
    

    public sClass job;

    public GameObject abilityObject;
    public Transform spawnPoint;

    void Update()
    {
        if (job == sClass.sniper)
        {
            if (Input.GetButton("Fire1"))
            {
                UseAbility();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                UseAbility();
            }
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
                GameObject hamsterBall = Instantiate(abilityObject, spawnPoint.position, Quaternion.identity);
                break;
            case sClass.sniper:
                RaycastHit Check;

                if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out Check, RaycastDistance))
                {
                    print(Check.collider.name);
                    opendoor doorCheck = Check.collider.GetComponent<opendoor>();
                    if (doorCheck != null)
                    {
                        if (doorCheck.locked)
                        {
                            timer += Time.deltaTime;
                            if (timer >= timeToUnlock)
                            {
                                Destroy(doorCheck.gameObject);
                            }
                        }
                    }
                }
                else timer = 0;
                    break;

            //raycast and timer for lockpick
        }
    }
}
