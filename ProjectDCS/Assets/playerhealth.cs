using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public int currenthealth;
    public int maxiumhealth = 100;
    public Text counttext;

    void Start()
    {
        currenthealth = maxiumhealth;
        counttext.text = "current health: " + currenthealth.ToString();
    }

    void Update()
    {
        counttext.text = "current health: " + currenthealth.ToString();
    }
}
