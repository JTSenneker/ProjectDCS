using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Hamseter_Ball : MonoBehaviour
{
    bool ballInEffect = false;
    public float cooldown;
    public float shieldRadius = 5f;
    
    void Start()
    {
        ballInEffect = true;
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TestThing"))
        {
            Destroy(this);
        }
    }
}
