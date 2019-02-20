using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathText : MonoBehaviour
{
    public Text healthText;
    public int health = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SetHealthText();
        InvokeRepeating("SetHealthText", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
