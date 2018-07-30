using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int setElement;
    private float dis = 3.0f;
    public Rigidbody[] worldModels;
    public Transform dropPosition;
    public Transform shootPoint;
    public int pistoleToDrop;
    public bool canTake;
    
 
   
    // Use this for initialization
    void Start () {
        weaponsInUse[0] = weaponInGame[selectWepSlot1];
        weaponsInUse[1] = weaponInGame[selectWepSlot2];

        weaponToSelect = 0;
        

    }
  

    // Update is called once per frame
    void Update () {
        #region Komentirano
        /* if (Input.GetKeyDown("1") && weaponInUser.Length >= 1 && weaponToSelect != 0)
         {
             StartCoroutine("DeselectWeapon");
             weaponToSelect = 0;
         }
         else if (Input.GetKeyDown("2") && weaponInUser.Length >= 2 &&  weaponToSelect != 1)
         {
             StartCoroutine("DeselectWeapon");
             weaponToSelect = 1;
         }

         if (Input.GetAxis("Mouse ScrollWheel") > 0 && canSwitch)
         {
             weaponToSelect++;
             if (weaponToSelect > (weaponInUser.Length - 1))
             {
                 weaponToSelect = 0;
             }
             StartCoroutine("DeselectWeapon");
         }

         if (Input.GetAxis("Mouse ScrollWheel") < 0 && canSwitch)
         {
             weaponToSelect--;
             if (weaponToSelect < 0)
             {
                 weaponToSelect = weaponInUser.Length - 1;
             }
             StartCoroutine("DeselectWeapon");
         }
         if (Input.GetKeyDown(KeyCode.P))
         {
             // WeaponIndex pre = transform.GetComponent<WeaponIndex>();
             setElement = 1;
             //DropWeapon(weaponToDrop);
             SelectWeapon(setElement);   
            // StartCoroutine("DeselectWeapon");
             weaponInUser[weaponToSelect] = weaponInUser[setElement];
             //Destroy(hit.transform.gameObject);
         }*/
        #endregion

        if (Input.GetKeyDown(KeyCode.E) && canTake)
        {
            TakeWeapon();

        }
        if (Input.GetKeyDown("1") && weaponsInUse[1] != null )
        {
            weaponsInUse[0].SetActive(false);
            weaponsInUse[1].SetActive(true);
            
        }
        else if (Input.GetKeyDown("2") && weaponsInUse[0] !=null  )
        { 
            weaponsInUse[1].SetActive(false);
            weaponsInUse[0].SetActive(true);
        }

    }

    private void TakeWeapon()
    {
        //Vector3 pos = transform.parent.position;
       // Vector3 dir = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, dis, layerMaskWeapon))
        {
            WeaponIndex pre = hit.transform.GetComponent<WeaponIndex>();
            setElement = pre.setWeapon;

            if (weaponsInUse[1] != weaponInGame[setElement])
            {
                
                weaponsInUse[1].SetActive(false);

                if(weaponsInUse[1] != weaponInGame[0])
                    DropWeapon(weaponToDrop);
                weaponsInUse[1] = weaponInGame[setElement];
                weaponsInUse[0].SetActive(false);
                weaponsInUse[1].SetActive(true);

                weaponToDrop = weaponsInUse[1].transform.GetComponent<WeaponIndex>().setWeapon;
                pre.isTaked = true;
            }
            else
            {
                Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();
                weapon.bulletLeft += weapon.bulletPerMag;
                pre.isTaked = true;
               
                
            }

        }
        else if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, dis, pistoljHladno))
        {
            WeaponIndex pre = hit.transform.GetComponent<WeaponIndex>();
            if (weaponsInUse[0] != weaponInGame[setElement])
            {
                
                int pIndex = pre.setWeapon;

                weaponsInUse[0].SetActive(false);
                if (weaponsInUse[0] != weaponInGame[0])
                    DropWeapon(weaponToDrop);
                weaponsInUse[0] = weaponInGame[pIndex];
                weaponsInUse[0].SetActive(true);
                weaponsInUse[1].SetActive(false);
                pistoleToDrop = weaponsInUse[0].transform.GetComponent<WeaponIndex>().setWeapon;
                pre.isTaked = true;
            }
            else
            {
                
                
                Weapon weapon = weaponsInUse[1].transform.GetComponent<Weapon>();
                weapon.bulletLeft += weapon.bulletPerMag;
                pre.isTaked = true;

            }

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
