
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("ouch");
        if (other.gameObject.CompareTag("Bullet")) {
            health--;
            Debug.Log(health);
        }
    }
}
