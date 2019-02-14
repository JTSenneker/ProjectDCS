using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class health : MonoBehaviour
{
    public float h = 100f;
    
   public Animator final;
    

    private void Start()
    {
        final = this.gameObject.GetComponent<Animator>();
       

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
        final.Play("die");
        Destroy(gameObject);
        
    }

    






}
