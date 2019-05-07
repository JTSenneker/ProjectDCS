using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public string safeTag;
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        
        if(other.GetComponent<Class_Stats_Final>() != null)
        {
            if(tag != "Health")
                other.GetComponent<Class_Stats_Final>().Hurt();
            else
                other.GetComponent<Class_Stats_Final>().currentHealth += 30;
        }
        if (other.tag != safeTag) Destroy(gameObject);
    }
}
