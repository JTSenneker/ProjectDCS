using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class health : MonoBehaviour
{
    public float h = 100f;

    public GameObject enemy;
    public Transform[] spawnPoints;
    public GameObject[] drops;
    private void Start()
    {
        
       

    }

    public void takedamage (float amount)
    {
        h -= amount;
        
        if (h <= 0f)
        {
            die();
        }
    }
    void die()
    {
       
        
        int dropIndex = Random.Range(0, drops.Length);
        Instantiate(drops[dropIndex], transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

    






}
