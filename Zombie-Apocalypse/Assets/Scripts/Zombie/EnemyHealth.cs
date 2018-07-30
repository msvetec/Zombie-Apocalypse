using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int startingHealth = 100;
    private int currentHealth;

    private Animator anim;
    public bool isDead = false;
    private NavMeshAgent nav;
    private Rigidbody rb;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDemage(int _amount)
    {
        if (isDead)
            return;
        currentHealth -= _amount;

        if (currentHealth <= 0)
        {
            Death();
        }
        
    }

    private void Death()
    {
        isDead = true;
        anim.SetTrigger("isDying");
        nav.enabled = false;
        rb.isKinematic = true;
        Destroy(gameObject, 4f);
        nav.enabled = false;


    }




}
