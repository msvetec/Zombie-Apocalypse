using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator anim;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    private AudioSource audioSource;

    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private int bulletPerMag = 30; //bullets per each magazine
    [SerializeField]
    private int bulletLeft = 200; // Total bullets we have
    [SerializeField]
    private int currentBullets; //The current bullets in our magazine
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float fireRate = 0.1f;
    float fireTimer;

    [SerializeField]
    private AudioClip shootSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentBullets = bulletPerMag;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
                Fire();
            else
                Reload();
        }
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
      
    }
    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        
    }
    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <=0)
        {
            return;

        }

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)) ;
        {
            
        }
        anim.CrossFadeInFixedTime("Fire",0.05f);
        muzzleFlash.Play();
        PlayShootSound();
        currentBullets--;
        fireTimer = 0.0f;
    }
    private void Reload()
    {
        if (bulletLeft <= 0) return;

        int bulletsToLoad = bulletPerMag - currentBullets;
        int bulletsToDeduct = (bulletLeft >= bulletsToLoad) ? bulletsToLoad : bulletLeft;

        bulletLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }

    private void PlayShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }



}
