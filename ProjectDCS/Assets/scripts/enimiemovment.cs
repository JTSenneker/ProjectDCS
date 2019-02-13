using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enimiemovment : MonoBehaviour
{
    NavMeshAgent agent;
   public Transform human;
   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
        
    }

    void Update()
    {

        agent.SetDestination(human.position);
    }


}
