using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityStandardAssets.Characters.FirstPerson;
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

    public float cooldownProgress { get { return _cooldownProgress; } }
    public float armorPercentage { get { return (currentArmor / maxArmor); } }
    public float healthPercentage { get { return (currentHealth / maxHealth); } }

    private float timer;
    private float _cooldownProgress;
    private Player player;

    public sClass job;

    public GameObject abilityObject;
    public Transform spawnPoint;

    private void Start()
    {
        currentArmor = maxArmor;
        currentHealth = maxHealth;
        timer = abilityCooldown;
        player = ReInput.players.GetPlayer(GetComponent<FirstPersonController>().controllerId);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= abilityCooldown) timer = abilityCooldown;
        _cooldownProgress = timer / abilityCooldown;

        if (currentHealth >= maxHealth) currentHealth = maxHealth;
        if (currentArmor >= maxArmor) currentArmor = maxArmor;
        
        if (job == sClass.sniper)
        {
            if (player.GetButton("Ability"))
            {
                UseAbility();
            }
        }
        else
        {
            if (player.GetButtonDown("Ability") && timer >= abilityCooldown) 
            {
                UseAbility();
                timer = 0;
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
                GameObject Medkit = Instantiate(abilityObject, spawnPoint.position, Quaternion.identity);
                Medkit.tag = "Player";
                break;
            case sClass.tank:
                GameObject hamsterBall = Instantiate(abilityObject, spawnPoint.position, Quaternion.identity);
                hamsterBall.tag = "Player";
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

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 10;
        }
    }

    public void Hurt()
    {
        if(currentArmor > 0)
        {
            currentArmor -= 10;
            if (currentArmor <= 0) currentArmor = 0;
        }
        else
        {
            currentHealth -= 10;
        }
        print("Armor: " + currentArmor + ", Health: " + currentHealth);
    }
}
