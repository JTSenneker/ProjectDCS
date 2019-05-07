using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIHandler : MonoBehaviour
{
    public Class_Stats_Final stats;
    public Image healthBar;
    public Image armorBar;
    public Image abilityIcon;
    public Image speedIcon;
    public Image powerIcon;

    public Text ammoText;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        armorBar.fillAmount = stats.armorPercentage;
        healthBar.fillAmount = stats.healthPercentage;
        abilityIcon.fillAmount = stats.cooldownProgress;
    }
}
