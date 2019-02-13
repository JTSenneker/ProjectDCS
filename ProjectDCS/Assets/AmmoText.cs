using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ClassType
{
    TANK,
    MEDIC,
    SNIPER,
    LIGHT
}

public class CharacterClasses : MonoBehaviour
{
    public ClassType classType;

    public Text ammoText;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;


    public int maxAmmo = 100;
    public int ammo = 100;

    void Start()
    {
        SetAmmoText();
    }



    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += Time.time + period;
            SetAmmoText();
        }
    }
    void SetAmmoText()
    {
        ammoText.text = ammo.ToString + " / " + maxAmmo.ToString;
    }
}
