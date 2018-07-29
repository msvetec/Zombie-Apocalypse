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







    private void Start()
    { 
        playerHealth = player.GetComponent<PlayerHealth>();
       
    }
    public void Equip(Equipment _newItem)
    {

        if (_newItem.equipSlot == EquipmentSlots.EnergyDrink)
        {
            playerHealth.hungerSlider.value += _newItem.hungerModifer;
        }
        if (_newItem.equipSlot == EquipmentSlots.Med)
        {
            playerHealth.healthSlider.value = 100;
        }

       

        

    }
}

