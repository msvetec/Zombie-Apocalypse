using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

    public GameObject[] weaponsInUse = new GameObject[2];
    public GameObject[] weaponInGame;
    [HideInInspector] public int weaponToDrop;
    private float switchWeaponTime = 0.25f;
    private int weaponToSelect;
    public int selectWepSlot1 = 0;
    public int selectWepSlot2 = 0;
    public LayerMask layerMaskWeapon;
    public LayerMask pistoljHladno;
    //public Camera shotPoint;
    //public int setElement;
    private float dis = 5.0f;
    public Rigidbody[] worldModels;
    public Transform dropPosition;
    public Transform shootPoint;
    public int pistoleToDrop;
    public bool canTake;

    public Image weaponSlot;
    public Image pistoleSlot;

   

    void Start () {
        weaponsInUse[0] = weaponInGame[selectWepSlot1];
        weaponsInUse[1] = weaponInGame[selectWepSlot2];
        weaponToSelect = 0;
        

    }
 
    void Update () {
      
        if (Input.GetKeyDown(KeyCode.F) && canTake)
        {
            TakeWeapon();

        }
        if (Input.GetKeyDown("1") && weaponsInUse[1] != null )
        {
            
            weaponsInUse[0].SetActive(false);
            weaponsInUse[1].SetActive(true);
            BulletsController.instance.slot1 = true;
            BulletsController.instance.slot2 = false;

        }
        else if (Input.GetKeyDown("2") && weaponsInUse[0] !=null  )
        { 
            weaponsInUse[1].SetActive(false);
            weaponsInUse[0].SetActive(true);
            BulletsController.instance.slot1 = false;
            BulletsController.instance.slot2 = true;
        }

    }
    
    private void TakeWeapon()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, dis, layerMaskWeapon))
        {
           WeaponIndex pre = hit.transform.GetComponent<WeaponIndex>();
           
           int setElement = pre.setWeapon;

            if (weaponsInUse[1] != weaponInGame[setElement])
            {
                weaponSlot.sprite = pre.weaponImage;
                weaponsInUse[1].SetActive(false);

                if (weaponsInUse[1] != weaponInGame[0])
                {
                    DropWeapon(weaponToDrop);
                    pre.isTaked = false;
                }
                weaponsInUse[1] = weaponInGame[setElement];
                weaponsInUse[0].SetActive(false);
                weaponsInUse[1].SetActive(true);

                Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();

                weaponToDrop = weaponsInUse[1].transform.GetComponent<WeaponIndex>().setWeapon;
                BulletsController.instance.activeWeapon = weaponToDrop;
                pre.isTaked = true;
                
                if (setElement == 1 || setElement == 2)
                {
                    weapon.bulletLeft = BulletsController.instance.akScar;
                }
                if (setElement == 3 || setElement == 5)
                {
                    weapon.bulletLeft = BulletsController.instance.b556;
                }
            }
            else
            {
                Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();
                if (setElement == 1 || setElement == 2)
                {
                    BulletsController.instance.akScar += weapon.bulletPerMag;
                }
                if (setElement == 3 || setElement == 5)
                {
                    BulletsController.instance.b556 += weapon.bulletPerMag;
                }
                //Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();
                BulletsController.instance.akScar += weapon.bulletPerMag;
                weapon.bulletLeft += weapon.bulletPerMag;
                pre.isTaked = true;
               
                
            }
            BulletsController.instance.slot1 = true;
            BulletsController.instance.slot2 = false;

        }
        else if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, dis, pistoljHladno))
        {
            WeaponIndex pre = hit.transform.GetComponent<WeaponIndex>();
            int pIndex = pre.setWeapon;
            pistoleSlot.sprite = pre.weaponImage;
            if (weaponsInUse[0] != weaponInGame[pIndex])
            {
                
                weaponsInUse[0].SetActive(false);
                if (weaponsInUse[0] != weaponInGame[0])
                {
                    DropWeapon(pistoleToDrop);
                    pre.isTaked = false;
                }
                weaponsInUse[0] = weaponInGame[pIndex];
                weaponsInUse[0].SetActive(true);
                weaponsInUse[1].SetActive(false);
                pre.isTaked = true;
                Weapon weapon = weaponsInUse[0].transform.GetComponent<Weapon>();
                pistoleToDrop = weaponsInUse[0].transform.GetComponent<WeaponIndex>().setWeapon;
                if (pIndex == 4 )
                {
                    weapon.bulletLeft = BulletsController.instance.deagleBullets;
                }
                
                BulletsController.instance.activePistole = pistoleToDrop;
                
            }
            else
            {

                Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();
                if (pIndex == 4)
                {
                    BulletsController.instance.deagleBullets += weapon.bulletPerMag;
                }
                weapon.bulletLeft += weapon.bulletPerMag;
                pre.isTaked = true;

            }
            BulletsController.instance.slot1 = false;
            BulletsController.instance.slot2 = true;

        }
                

    }
    void DropWeapon(int index)
    {
        if (index == 0) return;

        for (int i = 0; i < worldModels.Length; i++)
        {
            if (i == index)
            {
                
                Rigidbody drop = Instantiate(worldModels[i], dropPosition.transform.position, dropPosition.transform.rotation) as Rigidbody;
                drop.AddRelativeForce(0, 250, UnityEngine.Random.Range(100, 200));
                drop.AddTorque(-transform.up * 40);
            }
        }
    }


   
}
