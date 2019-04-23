using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    void OntriggerExit (Collider other)
    {
        Destroy(gameObject);
    }
}
