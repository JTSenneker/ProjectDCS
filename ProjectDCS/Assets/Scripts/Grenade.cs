using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //Jack of all Trades Ability
    public float delay = 3.0f;
    public float countdown;
    public GameObject explosion;
    bool boom = false;
    public float blastRadius = 5f;
    public float splash = 700f;

    void Start()
    {
        countdown = delay;
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !boom)
        {
            Explode();
            boom = true;
        }
        void Explode()
        {
            //Particles
            Instantiate(explosion, transform.position, transform.rotation);
            //Move Objects/Damage
            Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
            foreach (Collider nearbyObject in colliders)
            {
                //Damage
                Rigidbody RB = nearbyObject.GetComponent<Rigidbody>();
                if (RB != null)
                {
                    RB.AddExplosionForce(splash, transform.position, blastRadius);
                }
            }
            //Remove Grenade
            Destroy(gameObject);
        }
    }
}
