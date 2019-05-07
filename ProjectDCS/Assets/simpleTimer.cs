/*
 * A simple timer to deactivate the win object and 
 * start the credits automatically
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleTimer : MonoBehaviour {
    public GameObject creditsObject;  
    public GameObject winObject; 
    public float timeLimit;

    // Update is called once per frame
    void Update() {
        timeLimit -= Time.deltaTime;

        if(timeLimit <= 0.0f) {
            timeEnd();
        }
    }

    void timeEnd() {
        //do stuff here when timer ends
        winObject.SetActive(false);
        creditsObject.SetActive(true);        
    }
}
