using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public Text timer;
    private PlayerMovement myPlayer = new PlayerMovement();
    private int nextUpdate = 1;
    private int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = $"Running for {seconds} seconds...";
        //InvokeRepeating("PerSecondUpdate", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate) {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            PerSecondUpdate();
        }
    }

    void PerSecondUpdate() {
        seconds++;
        timer.text = $"Running for {seconds} seconds...";
        Debug.Log("Called PerSecondUpdate()");
    }
}
