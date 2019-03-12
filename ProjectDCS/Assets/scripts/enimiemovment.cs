using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enimiemovment : MonoBehaviour
{
     public NavMeshAgent agent;
    public Transform target;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    void Update()
    {

        agent.SetDestination(target.position);
    }

     public void SetTarget(Transform Target)
    {
        target = Target; 
    }


}
