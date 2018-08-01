using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public int space = 5;
    public bool inventoryOn;
    
    public bool torbaPuna = false;
    
    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.Log("pronadeno vise on jedne istance");
        }
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<Item> items = new List<Item>();
    private void Update()
    {
        if (items.Count >= space)
        {

            torbaPuna = true;
        }
        else
            torbaPuna = false;

    }
    public bool Add(Item _item)
    {
        

        if (items.Count >= space)
        { 
      
            return false;
        }
  
        items.Add(_item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        return true;
       
    }

    public void Remove(Item _item)
    {
        items.Remove(_item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
    

}
