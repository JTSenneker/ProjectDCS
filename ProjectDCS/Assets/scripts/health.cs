using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class health : MonoBehaviour
{
    public float h = 100f;
    
   
    

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
       
        Destroy(gameObject);
        
    }

    






}
