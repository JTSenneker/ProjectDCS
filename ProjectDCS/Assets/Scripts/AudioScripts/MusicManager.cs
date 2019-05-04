using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Music Manager will use a singleton design pattern so we can have a persistant MusicManager script through the game.
//This script is to handle Background Music for the game
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    //this is what you'll reference when calling this class' methods
    public static MusicManager Instance { get; private set; }

    public AudioSource audioSource { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        //if we don't already have an instance of this class
        if(Instance == null)
        {
            //assign this particular instance of the script to the instance property
            Instance = this;
            DontDestroyOnLoad(gameObject);//once we've done this, tell us not to destroy this object when loading a new scene
        }
        else//if there's already an instance of this script we want to destroy this object
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    public IEnumerator FadeOut(float timeToFade)
    {
        float currentVolume = audioSource.volume;
        for (float time = 0; time <= timeToFade; time += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(currentVolume, 0, time/timeToFade);
            yield return null;
        }
    }

    //function used to call the fadeout coroutine. this is mostly used for buttons on the UI
    public void CallFadeOut(float timeToFade)
    {
        StartCoroutine(FadeOut(timeToFade));
    }

    //changes the music in the audio source
    public void ChangeMusic(AudioClip song,bool loop = true)
    {
        audioSource.Stop();
        audioSource.volume = .75f;
        audioSource.clip = song;
        audioSource.Play();
        audioSource.loop = loop;
    }
}
