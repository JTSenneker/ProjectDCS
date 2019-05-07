using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDefeated : MonoBehaviour
{
    void Update() {
        if(GetComponent<Boss>().health <= 0) {
            SceneManager.LoadScene("Credits");
        }
    }
}
