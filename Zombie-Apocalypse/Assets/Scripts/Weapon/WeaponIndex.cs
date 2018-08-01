
using UnityEngine;
using UnityEngine.UI;

public class WeaponIndex : MonoBehaviour {

    public int setWeapon;
    public GameObject player;
    public GameObject wManager;
    private WeaponManager wm;
    public bool isTaked;

    public int takeBullets;
    public string weaponName;

    
    public Sprite weaponImage;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wManager = GameObject.FindGameObjectWithTag("WManager");
        wm = wManager.GetComponent<WeaponManager>();
        
        isTaked = false;
    }

    private void Update()
    {
        if (isTaked)
        {
            
            this.gameObject.SetActive(false);

        }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            wm.canTake = true;
            
            

        }
        
    }private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            wm.canTake = false;
           
        }
    }



}
