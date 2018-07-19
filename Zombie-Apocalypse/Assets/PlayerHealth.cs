using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int startingHealth = 100;
    public int currentHealth;
    private bool isDemage = false;

    private void Awake()
    {
        currentHealth = startingHealth;

    }

    public void TakeDemage(int _amount)
    {
        isDemage = true;
        currentHealth -= _amount;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        //menu
        //pause game
    }


}
