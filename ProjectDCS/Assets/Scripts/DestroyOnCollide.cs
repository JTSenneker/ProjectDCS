using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
