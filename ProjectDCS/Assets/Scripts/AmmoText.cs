using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Text ammoText;

    public int ammo = 100;
    public int maxAmmo = 100;

    // Start is called before the first frame update
    void Start()
    {
        SetAmmoText();
        InvokeRepeating("SetAmmoText", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetAmmoText()
    {
        ammoText.text ="Ammo: " + ammo + "/" + maxAmmo;
    }
    
}
