using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityStandardAssets.Characters.FirstPerson;

public enum EnemyState {
    ATTACKING,
    WALKING
}

public class EnemyMovement : MonoBehaviour
{
    public EnemyState enemyState = EnemyState.WALKING;
    public NavMeshAgent agent;
    public Transform target = null;
    public List<Transform> targets = new List<Transform>();
    float rangeSqr = 10;
    bool canAttack = true;
    public Animator anim;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        foreach (FirstPersonController get in FindObjectsOfType<FirstPersonController>()) {
            targets.Add(get.GetComponent<Transform>());
        }
        SelectTarget();
        Invoke("SwitchToAttack", 5);
    }

    void Update() {
        //if (target != null) {
        //    agent.SetDestination(target.position);
        //}
        if (enemyState == EnemyState.WALKING) {
            agent.SetDestination(target.position);
        }
        if (enemyState == EnemyState.ATTACKING) {
            agent.SetDestination(transform.position);
            if (canAttack) {
                Invoke("Attack", 1);
                canAttack = false;
            }
        }
    }

    public void Attack() {
        GetComponent<BossShoot>().enabled = true;
        Invoke("SwitchToWalking", 5);
    }

    public void SwitchToAttack() {
        enemyState = EnemyState.ATTACKING;
        anim.SetBool("Walking", true);
        canAttack = true;
    }

    public void SwitchToWalking() {
        GetComponent<BossShoot>().enabled = false;
        SelectTarget();
        enemyState = EnemyState.WALKING;
        anim.SetBool("Walking", true);
        Invoke("SwitchToAttack", 5);
    }

    public void SelectTarget() {
        int index = Random.Range(0, targets.Count);
        target = targets[index];
    }

    public void SetTarget(Transform Target) {
        target = Target;
    }
}
