using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    public static EquipmentManager instance;
    public GameObject player;
    private PlayerHealth playerHealth;
   
   
 

    private void Awake()
    {


        instance = this;

    }
    private void Update()
    {
     
    }


    private void Start()
    { 
        playerHealth = player.GetComponent<PlayerHealth>();
       
       
    }
    public void Equip(Equipment _newItem)
    {

        if (_newItem.equipSlot == EquipmentSlots.EnergyDrink)
        {
            playerHealth.hungerSlider.value += _newItem.hungerModifer;
            playerHealth.healthSlider.value += _newItem.medModifier;
        }
        if (_newItem.equipSlot == EquipmentSlots.Pepsi)
        {
            playerHealth.hungerSlider.value += _newItem.hungerModifer;
            playerHealth.healthSlider.value += _newItem.medModifier;
        }
        if (_newItem.equipSlot == EquipmentSlots.Med)
        {
            playerHealth.healthSlider.value += _newItem.medModifier;
        }
        if (_newItem.equipSlot == EquipmentSlots.Zavoji)
        {
            playerHealth.healthSlider.value += _newItem.medModifier;
        }
        if (_newItem.equipSlot == EquipmentSlots.Banana)
        {
            playerHealth.hungerSlider.value += _newItem.hungerModifer;
        }
        //bullets
        if (_newItem.equipSlot == EquipmentSlots.AkScar)
        {
            BulletsController.instance.akScar += _newItem.bulletsModifer;
        }
        if (_newItem.equipSlot == EquipmentSlots.B556)
        {
            BulletsController.instance.b556 += _newItem.bulletsModifer;
        }
        if (_newItem.equipSlot == EquipmentSlots.DeagleBullets)
        {
            BulletsController.instance.deagleBullets += _newItem.bulletsModifer;
        }









    }
}

