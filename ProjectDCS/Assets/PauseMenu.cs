using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            if(isPaused) {
                Resume();
            } else {
                Pause();
            }
        }    
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
