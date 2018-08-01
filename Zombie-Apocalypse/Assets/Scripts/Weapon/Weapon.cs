﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// sami-shooting mode za scope ili pistolje -> FPS Tutorial Series #06
// odvojit specifikacije oruzja u drugu klasu

public class Weapon : MonoBehaviour
{

    private Animator anim;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    private AudioSource audioSource;
    
    [SerializeField]
    private float range;
    
    public int bulletPerMag; //bullets per each magazine
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private int demage;

 

    
    public int bulletLeft; // Total bullets we have
    [SerializeField]
    private int currentBullets; //The current bullets in our magazine
    [SerializeField]
    private Transform shootPoint;
   
    

    

    private float fireTimer;
    [SerializeField]
    private GameObject hitParicles;
    [SerializeField]
    private AudioClip shootSound;
    [SerializeField]
    private AudioClip reloadSound;

    private bool isReloding;

    [SerializeField]
    private float spreadFactor = 0.1f;

    public GameObject inventory;
    

    public bool isActive;


    private void Awake()
    {
        bulletLeft = 0;
        anim = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();
       
        currentBullets = bulletPerMag;

    }

    private void Update()
    {

        


        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0 && !Inventory.instance.inventoryOn)
                Fire();
            else if (bulletLeft > 0)
                DoReload();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            BulletsSet();
            
            if (currentBullets < bulletPerMag && bulletLeft > 0)
                DoReload();
        }
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        isReloding = info.IsName("reload");


    }
    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <= 0 || isReloding)
        {
            return;

        }

        RaycastHit hit;
        //recoil
        Vector3 shootDirection = shootPoint.transform.forward;
        shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
        shootDirection.y += Random.Range(-spreadFactor, spreadFactor);
        if (Physics.Raycast(shootPoint.position, shootDirection, out hit, range))
        {
            GameObject hitParticelsEffect = Instantiate(hitParicles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDemage(demage);
            }
            Destroy(hitParticelsEffect, 1f);
            

        }
        anim.CrossFadeInFixedTime("fire", 0.05f);
        muzzleFlash.Play();
        PlayShootSound();
        currentBullets--;
        fireTimer = 0.0f;
    }
    public void Reload()
    {
        
        if (bulletLeft <= 0) return;

        int bulletsToLoad = bulletPerMag - currentBullets;
        int bulletsToDeduct = (bulletLeft >= bulletsToLoad) ? bulletsToLoad : bulletLeft;

        bulletLeft -= bulletsToDeduct;
        BulletsALLControll(bulletsToDeduct);
        currentBullets += bulletsToDeduct;
        Debug.Log("ajde vise u pm");
       


    }
    private void DoReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (isReloding) return;

        PlayReloadSound();
        anim.CrossFadeInFixedTime("reload", 0.01f);
    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);

    }
    private void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadSound);

    }
    private void BulletsSet()
    {
        if (BulletsController.instance.activeWeapon == 1 || BulletsController.instance.activeWeapon == 2)
        {
            bulletLeft = BulletsController.instance.akScar;
        }
        if (BulletsController.instance.activeWeapon == 3 || BulletsController.instance.activeWeapon == 5)
        {
            bulletLeft = BulletsController.instance.b556;
        }
        if (BulletsController.instance.activePistole == 4)
        {
            bulletLeft = BulletsController.instance.deagleBullets;
        }
    }
    private void BulletsALLControll( int _bulletsToDeduct)
    {
        if ((BulletsController.instance.activeWeapon == 1 || BulletsController.instance.activeWeapon == 2) && BulletsController.instance.slot1)
        {
            BulletsController.instance.akScar -= _bulletsToDeduct;
        }
        if ((BulletsController.instance.activeWeapon == 3 || BulletsController.instance.activeWeapon == 5)&& BulletsController.instance.slot1)
        {
            BulletsController.instance.b556 -= _bulletsToDeduct;
        }
        if (BulletsController.instance.activePistole == 4 && BulletsController.instance.slot2)
        {
            BulletsController.instance.deagleBullets -= _bulletsToDeduct;
        }
    }
   



}