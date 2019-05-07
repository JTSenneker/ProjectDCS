using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsManager : MonoBehaviour
{
    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.ChangeMusic(bgm);
    }

   public void SwitchToMain()
    {
        SceneManager.LoadScene("mainMenu");

    }
}
