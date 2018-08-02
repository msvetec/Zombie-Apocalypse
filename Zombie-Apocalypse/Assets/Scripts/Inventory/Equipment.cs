using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Equpment", menuName ="Inventory/Equpment")]
public class Equipment : Item {
    public EquipmentSlots equipSlot;

    [Header("Equipment")]
    public int medModifier;
    public int hungerModifer;
    public int bulletsModifer;







    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventor();

    }


}

public enum EquipmentSlots { Med, EnergyDrink, Bullets, DeagleBullets, Pepsi, Zavoji, Banana, Kruh, AkScar,B556 }
	

