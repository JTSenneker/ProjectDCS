using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(!other.CompareTag("Player"))Destroy(gameObject);
    }
}
