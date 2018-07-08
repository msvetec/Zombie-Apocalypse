using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// sami-shooting mode za scope ili pistolje -> FPS Tutorial Series #06
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
    private GameObject hitParicles;
    [SerializeField]
    private GameObject bulletImpact;
  

    [SerializeField]
    private AudioClip shootSound;

    private bool isReloding;

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
            else if(bulletLeft > 0)
                DoReload();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(currentBullets<bulletPerMag && bulletLeft>0)
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
        isReloding = info.IsName("Reload");


    }
    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <=0 || isReloding)
        {
            return;

        }

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)) ;
        {
            GameObject hitParticelsEffect = Instantiate(hitParicles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));

            Destroy(hitParticelsEffect, 1f);
            Destroy(bulletHole, 2f);

        }
        anim.CrossFadeInFixedTime("Fire",0.05f);
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

        anim.CrossFadeInFixedTime("Reload", 0.01f);


    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
        
    }



}
