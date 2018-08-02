using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    public static EquipmentManager instance;
    public GameObject player;
    private PlayerHealth playerHealth;
    public GameObject useObject;
    public Slider useSlider;
    private int useStartValue;
    private int useMaxValue;
    public float useChangeRateValue;
    private bool move;
    private bool done;
    private bool klik;
    public bool canDelete;

    public float timer;

    private Equipment newItem;



    private void Awake()
    {

        
        instance = this;

    }

    private void Update()
    {
        move = player.GetComponent<FirstPersonController>().walk;
        if (klik && !move)
        {
            useObject.SetActive(true);
            useSlider.value += (Time.deltaTime + useChangeRateValue);
            if (useSlider.value == useMaxValue)
            {
                UseItem(newItem);
                useObject.SetActive(false);
                useSlider.value = useStartValue;
                klik = false;
                //canDelete = true;

            }
            // DrinkEnergy();
            
           // klik = false;
        }
        else
        {
            useObject.SetActive(false);
            //canDelete = false;
            klik = false;
            return;
        }
    }


    private void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        useStartValue = 0;
        useMaxValue = 100;
        useSlider.value = useStartValue;
        useSlider.maxValue = useMaxValue;
        useObject.SetActive(false);
        done = false;
        klik = false;
       

    }
    public void Equip(Equipment _newItem)
    {
        newItem = new Equipment();
        if (_newItem.equipSlot == EquipmentSlots.EnergyDrink)
        {
            //item = 0;
            useChangeRateValue = 1;
            newItem = _newItem;
            
            klik = true;
           

        }
        if (_newItem.equipSlot == EquipmentSlots.Pepsi)
        {
            //item = 1;
            newItem = _newItem;
            useChangeRateValue = 1;
            klik = true;

            
        }
        if (_newItem.equipSlot == EquipmentSlots.Med)
        {
            // item = 2;
            useChangeRateValue = 0.1f;
            newItem = _newItem;
           
            klik = true;
            
        }
        if (_newItem.equipSlot == EquipmentSlots.Zavoji)
        {
            //item = 3;
            useChangeRateValue = 0.2f;
            newItem = _newItem;
           
            klik = true;
            
        }
        if (_newItem.equipSlot == EquipmentSlots.Banana)
        {
            //item = 4;
            newItem = _newItem;
            useChangeRateValue = 1f;
            klik = true;
            
        }
        if (_newItem.equipSlot == EquipmentSlots.Kruh)
        {
           // item = 5;
            newItem = _newItem;
            useChangeRateValue = 0.2f;
            klik = true;
        }
        //bullets
        if (_newItem.equipSlot == EquipmentSlots.AkScar)
        {
            canDelete = true;
            klik = false;
            
            BulletsController.instance.akScar += _newItem.bulletsModifer;
        }
        if (_newItem.equipSlot == EquipmentSlots.B556)
        {
            klik = false;
            canDelete = true;
            
            BulletsController.instance.b556 += _newItem.bulletsModifer;
        }
        if (_newItem.equipSlot == EquipmentSlots.DeagleBullets)
        {
            klik = false;
            canDelete = true;
            
            BulletsController.instance.deagleBullets += _newItem.bulletsModifer;
        }
    }
    private void UseItem(Equipment _newItem)
    {
       playerHealth.hungerSlider.value += _newItem.hungerModifer;
       playerHealth.healthSlider.value += _newItem.medModifier;
      
    }
  
}

