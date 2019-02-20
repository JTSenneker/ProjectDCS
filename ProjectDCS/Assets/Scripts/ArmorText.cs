using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorText : MonoBehaviour
{
    public Text armorText;
    public int armor = 100;


    // Start is called before the first frame update
    void Start()
    {
        SetArmorText();
        InvokeRepeating("SetArmorText", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetArmorText()
    {
        armorText.text = "Armor: " + armor.ToString();
    }
}