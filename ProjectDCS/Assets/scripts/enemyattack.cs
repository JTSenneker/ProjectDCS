using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
 public enum EnemyState{Idle,Aggro,Attacking}
public class enemyattack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public float maxditcance;
    public float cooldowntime;
    public Text healthtext;
    public EnemyState state;
    float timer;
    bool playerInRange;


    private Transform mytransform;
    public Transform target;
    public playerhealth ph;
    enimiemovment movement;
    public health enemyhealth;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<enimiemovment>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mytransform = transform;
        maxditcance = 3;
        cooldowntime = 1;



    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Aggro:
                movement.SetTarget(target);
                if (Vector3.Distance(transform.position, target.position) > 5)
                {
                    state = EnemyState.Idle;
                }
                break;
            case EnemyState.Idle:
                target = null;
                movement.enabled = false;
                playerInRange = false;
                break;
            case EnemyState.Attacking:


                break;
        }

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyhealth.h > 0)
        {
            // ... attack.
            Attack();
        }


    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log(target.name);

            if (target == null)
            {
                state = EnemyState.Aggro;
                target = other.transform;
                movement.enabled = true;
                playerInRange = true;

            }


        }

    }

    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (ph.currenthealth > 0)
        {
            state = EnemyState.Attacking;
            // ... damage the player.
            ph.currenthealth = ph.currenthealth - 50;
        }
    }
}

