using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour {

    public int deagleBullets;
    public int b556;
    public int akScar;

    public int activeWeapon;
    public int activePistole;

    public bool slot1;
    public bool slot2;
    public static BulletsController instance;
    private void Start()
    {
        instance = this;
        deagleBullets = 0;
        b556 = 0;
        akScar = 0;
    }


   
}
