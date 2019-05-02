using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject pauseCanvas; //canvas for the pause menu
    public GameObject mainCanvas; //main canvas for menus
    public GameObject PauseMenuUI; //UI for the pause menu (buttons, etc)
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        //clear the placeholder resolutions from the list
        resolutionDropdown.ClearOptions();

        //create a list of avaiable resolutions that the game can run at
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        //Add resolutions to the list
        for(int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    public void setResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

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
        //PauseMenuUI.SetActive(false);
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

    public void setFullscreen(bool fullScreen) {
        //Set fullscreen on or off
        Screen.fullScreen = fullScreen;
    }
}
