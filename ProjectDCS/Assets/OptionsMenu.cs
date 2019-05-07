using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

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

    public void setVolume(float volume) {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }

    // 0 = very low, 5 = ultra
    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool fullScreen) {
        //Set fullscreen on or off
        Screen.fullScreen = fullScreen;
    }
}
