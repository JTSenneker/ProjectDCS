using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public enum ClassType
    {
        TANK,
        MEDIC,
        SNIPER,
        LIGHT
    }

    public ClassType classType;

    public Text healthText;
    int health = 0;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Start()
    {
        SetHeathText();
    }


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += Time.time + period;
            
        }
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
