using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType : string {
    AUTO = "auto",
    SEMI = "semi",
    BURST = "burst",
    BEAM = "beam"
}

public class Weapons : MonoBehaviour
{
    public WeaponType weaponType;
    public int burstCount; // How many rounds shot when trigger pressed.
    public int ammo; // Current ammo in clip.
    public int maxAmmo; // Max ammo in one clip.
    public int fireRate; // How many rounds per second.
    public int damage; // How many Hit Point each hit takes away from the object that is hit.
    public int range; // How far the bullets go in feet.
    public int reloadSpeed; // How many milliseconds it takes for the clip to reload.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (WeaponType) {
            case WeaponType.AUTO:
                burstCount = 1;
                ammo = 200;
                maxAmmo = 200;
                fireRate = 20;
                damage = 25;
                range = 50;
                reloadSpeed = 3000;
                break;
            case WeaponType.SEMI:
                burstCount = 1;
                ammo = 50;
                maxAmmo = 50;
                fireRate = 2;
                damage = 40;
                range = 70;
                reloadSpeed = 500;
                break;
            case WeaponType.BURST:
                burstCount = 3;
                ammo = 100;
                maxAmmo = 100;
                fireRate = 3;
                damage = 40;
                range = 70;
                reloadSpeed = 700;
                break;
            case WeaponType.BEAM:
                burstCount = 1;
                ammo = 20;
                maxAmmo = 20;
                fireRate = 1;
                damage = 100;
                range = 100;
                reloadSpeed = 4000;
                break;
            default:
                break;
        }
    }
}
