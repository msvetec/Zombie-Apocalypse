using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsContoller : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource;

    public int demage;
    public AudioClip hitSound;
    public Transform shootPoint;
    public int range;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && !Inventory.instance.inventoryOn)
        {
            anim.CrossFadeInFixedTime("Swing02", 0.01f);
            Invoke("HitZombie", 0.8f);
           
        }
    }

    private void HitZombie()
    {
        RaycastHit hit;
        Vector3 shootDirection = shootPoint.transform.forward;
        
        if (Physics.Raycast(shootPoint.position, shootDirection, out hit, range))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDemage(demage);
            }
        }
        
        //PlayHitSound();
    }
    private void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
