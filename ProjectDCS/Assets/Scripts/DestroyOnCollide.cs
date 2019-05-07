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
            other.GetComponent<Class_Stats_Final>().Hurt();
        }
        if (!other.CompareTag(safeTag)) Destroy(gameObject);
    }
}
