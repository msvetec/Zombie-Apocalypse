using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour {
    public GameObject weapon;
    public GameObject test;
    private bool isActive;
  
   
    //public GameObject w1;
    //public GameObject w2;
    //public GameObject w3;


    private void Awake()
    {
        isActive = test.GetComponent<Weapon>().isActive;
        Switch();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Switch();
        }
    }

    private void Switch()
    {
        foreach (Transform weapon in transform)
        {
            if (isActive)
            {
                weapon.gameObject.SetActive(true);
            }
        }
       
    }


}
