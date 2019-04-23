using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;

    public void setVolume(float volume) {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }

    // 0 = very low, 5 = ultra
    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
