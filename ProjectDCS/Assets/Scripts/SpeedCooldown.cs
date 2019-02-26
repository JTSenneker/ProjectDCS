using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCooldown : MonoBehaviour
{
    public Text speedCool;
    private PlayerMovement myPlayer = new PlayerMovement();
    int speedCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdatePerSec", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePerSec() {
        speedCoolDown = myPlayer.speedCooldown;
        speedCool.text = $"S: {speedCoolDown}";
    }
}
