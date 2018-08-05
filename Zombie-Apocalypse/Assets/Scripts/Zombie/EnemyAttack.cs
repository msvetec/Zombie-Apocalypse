using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

    [SerializeField]
    private float timebetweenAttacks = 0.5f;
    [SerializeField]
    private int attackDemage = 10;
    [SerializeField]
    private Transform player;

    private Animator anim;
    private float timer;
    private NavMeshAgent nav;

    private PlayerHealth playerHealth;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timebetweenAttacks)
        {
            Attack();
        }
        
    }



    private void Attack()
    {
        timer = 0f;
        if (Vector3.Distance(player.position, this.transform.position) < 1.5f)
        {
            nav.speed = 0.5f;
            //nav.Stop();
            anim.speed = 1f;
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
            playerHealth.TakeDemage(attackDemage);
          
        }
        else
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            
        }

    }



}
