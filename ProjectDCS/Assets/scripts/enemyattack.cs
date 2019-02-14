using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class enemyattack : MonoBehaviour
{
    public float maxditcance;
    public float cooldowntime;
    

    private Transform mytransform;
    public Transform target;
     Animator controller;
    // Start is called before the first frame update
    void Start()
    {
         
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mytransform = transform;
        maxditcance = 3;
        cooldowntime = 1;
        controller = this.gameObject.GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, mytransform.position);
        if (distance < maxditcance)
        {
            attack();
            controller.Play("attack");
            
        }
        if (cooldowntime > 0)
        {
            cooldowntime = cooldowntime * Time.deltaTime;
        }
    }
    void attack()
    {
        if (cooldowntime == 0)
        {
            
            cooldowntime = 1;
        }

    }
}
