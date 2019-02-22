using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpscam;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        { 
      
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hit;
       if  (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
       {
            Debug.Log(hit.transform.name);
            health target = hit.transform.GetComponent<health>();
            if (target != null)
            {
                target.takedamage(damage);
            }
       }
    }
}
