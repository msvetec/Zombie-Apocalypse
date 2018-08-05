using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int startingHealth = 100;
   // public int currentHealth;
    private bool isDemage = false;
    
    public Slider healthSlider;
    [SerializeField]
    private int healthFallRate = 10;
    
    public Slider hungerSlider;
    [SerializeField]
    private int hungerFallRate = 10;
    [SerializeField]
    private int maxHunger = 100;
    public AudioClip hurtSound;
    private AudioSource audioSource;
    

    private bool isDeath = false;

    private void Awake()
    {
        //currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;
        audioSource = transform.GetComponent<AudioSource>();
        


    }
    private void Update()
    {
        HungerControll();
        if (isDeath)
        {
            Death();
        }


    }

    public void TakeDemage(int _amount)
    {
        isDemage = true;//najvjerojatnije nicemu ne sluzi provjeriti!!!
        healthSlider.value -= _amount;
        PlaySound();
        if (healthSlider.value <= 0)
        {
            Death();


        }
    }

    private void Death()
    {
        Debug.Log("Mrtav");
        //menu
        //pause game
    }
    private void HungerControll()
    {
        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerFallRate*10;
        }
        if (hungerSlider.value <= 0)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate*10;
        }
        if (healthSlider.value <= 0)
        {
            isDeath = true;
        }

    }
    private void PlaySound()
    {
        audioSource.PlayOneShot(hurtSound);
    }


}
