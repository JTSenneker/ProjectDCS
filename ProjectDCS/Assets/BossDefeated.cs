using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDefeated : MonoBehaviour
{
    public void OnDestroy()
    {
        SceneManager.LoadScene("Credits");
    }
}
