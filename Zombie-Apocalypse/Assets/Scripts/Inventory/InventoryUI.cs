
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;
    public Transform itemsPerent;
    InventorySlot[] slots;
    private bool klick = true;
    public GameObject inventoryUI;
    public bool isInventory = false;
    public GameObject player;
    
    
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;
   
   


    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsPerent.GetComponentsInChildren<InventorySlot>();
       
        firstPersonController = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        

    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
           
            klick = !klick;

            if (klick)
            {
                inventoryUI.SetActive(true);
                
                firstPersonController.enabled = false;
                Inventory.instance.inventoryOn = true;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                isInventory = true;
                
                
            }
            else
            {
                inventoryUI.SetActive(false);
                Cursor.visible = false;
                isInventory = false;
                firstPersonController.enabled = true;
                Inventory.instance.inventoryOn = false;

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
