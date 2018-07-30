
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;
    public Transform itemsPerent;
    InventorySlot[] slots;
    private bool klick = true;
    public GameObject inventoryUI;
    public bool isInventory = false;
   


    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsPerent.GetComponentsInChildren<InventorySlot>();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            //inventoryUI.SetActive(!inventoryUI.activeSelf);
            klick = !klick;




            if (klick)
            {
                inventoryUI.SetActive(true);
                Cursor.visible = true;
                isInventory = true;
            }
            else
            {
                inventoryUI.SetActive(false);
                Cursor.visible = false;
                isInventory = false;
                
            }
        }
    }
   

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }


}
