using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public int space = 5;
    

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

    public bool Add(Item _item)
    {
        if (items.Count >= space)
        {
            Debug.Log("torba je puna");
           
            return false;
        }
        if (_item.name == "kalas")
        {
            //
        }
        items.Add(_item);
        if(onItemChangedCallBack != null)
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
