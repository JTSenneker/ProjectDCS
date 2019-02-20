using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainAbility : MonoBehaviour
{
    public Text abilityText;

    int coolDownAbility = 0;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CoolDown", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CoolDown()
    {
        abilityText.text = "Ability Cooldown: " + coolDownAbility;

        if (coolDownAbility > 0)
        {
            coolDownAbility--;
        }
    }
}
