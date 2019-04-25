using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public bool isPlaying = false;
    public void playGame() {
        //load the next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isPlaying = true;
    }


    public void quitGame() {

        Application.Quit();
        Debug.Log("Game Quit");
    }


}
