using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class opendoor : MonoBehaviour
{
    bool interactive;
   public void Open()
   {
        Destroy(gameObject);
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        interactive = true;
    }

    void OnTriggerExit(Collider other)
    {
        interactive = false;
    }
}
