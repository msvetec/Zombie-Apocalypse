using System.Collections;
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
    [SerializeField]
    private int bulletPerMag; //bullets per each magazine
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private int demage;

 

    [SerializeField]
    private int bulletLeft = 200; // Total bullets we have
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
    private InventoryUI invUi;


    private void Awake()
    {
        
        anim = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();
        invUi = inventory.GetComponent<InventoryUI>();
        currentBullets = bulletPerMag;

    }

    private void Update()
    {
        if (invUi.isInventory)
            return;
        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
                Fire();
            else if (bulletLeft > 0)
                DoReload();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
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
        currentBullets += bulletsToDeduct;
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
   



}