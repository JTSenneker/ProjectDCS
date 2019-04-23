using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject pauseCanvas; //canvas for the pause menu
    public GameObject mainCanvas; //main canvas for menus
    public GameObject PauseMenuUI; //UI for the pause menu (buttons, etc)


    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            if(isPaused) {
                resume();
            } else {
                pause();
            }
        }    
    }

   public void resume() {
        isPaused = false;
        Time.timeScale = 1; //time is normal speed

        PauseMenuUI.SetActive(false);
        pauseCanvas.SetActive(false);
        Debug.Log(Time.timeScale);
        
    }

    void pause() {
        isPaused = true;
        PauseMenuUI.SetActive(true);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0; //completely freeze game
        
    }

    public void QuitGame() {
        Debug.Log("Quit Game from Pause Menu");
    }
}
