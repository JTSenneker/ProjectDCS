using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float shotDelay = 1;
    bool canShoot = true;
    public GameObject shot;
    public Transform shotSpawn;

    // Update is called once per frame
    void Update()
    {
        if (canShoot) {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            canShoot = false;
            Invoke("ResetCanShoot", shotDelay);
        }
    }

    void ResetCanShoot() {
        canShoot = true;
    }
}
