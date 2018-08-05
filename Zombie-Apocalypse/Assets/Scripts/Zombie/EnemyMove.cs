using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    public float timer;
    public int newTarger;
    public float speed;
    private NavMeshAgent nav;
    public Vector3 target;
    private GameObject player;
    private bool seePlayer;
    public Transform playerPosition;
    private Animator anim;
    public Transform zombiePosition;
    public Vector3 lastPosition;
    private EnemyHealth health;
    private Transform playerPostion;

    public AudioClip[] zombieSounds;
    private AudioSource audioSource;
   


    private void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        player = PlayerManager.instance.player;
        anim = gameObject.GetComponent<Animator>();
        zombiePosition = gameObject.GetComponent<Transform>();
        health = gameObject.GetComponent<EnemyHealth>();
        lastPosition = new Vector3();
        seePlayer = false;
       
        playerPosition = player.transform;
        audioSource = player.GetComponent<AudioSource>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        InvokeRepeating("CheckMovmend", 0, 1.0f);
        timer += Time.deltaTime;

        if (timer >= newTarger && seePlayer == false && !health.isDead)
        {
            
            NewTarget();
            
            timer = 0;
        }
        else if (seePlayer && !health.isDead)
        {
            MoveToPlayer();
            FacePlayer();

        }
        if (health.isDead)
        {
            audioSource.Stop();
        }
       
    }

    private void NewTarget()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - 100, myX + 100);
        float zPos = myZ + Random.Range(myZ - 100, myZ + 100);

        target = new Vector3(xPos, gameObject.transform.position.y, zPos);
        nav.speed = 2;
        anim.speed = 1.5f;
        nav.SetDestination(target);
        
        

    }
    private void MoveToPlayer()
    {
        nav.speed = 5;
        anim.speed = 2; 
        nav.SetDestination(playerPosition.position);
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            seePlayer = true;
            PlaySound();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            seePlayer = false;
            
        }
            
        
    }
    private void CheckMovmend()
    {
        if (zombiePosition.transform.hasChanged)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }
    }
    private void FacePlayer()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime );
    }
    private void PlaySound()
    {
        int randomClips = Random.Range(0, zombieSounds.Length);
        audioSource.PlayOneShot(zombieSounds[randomClips]);
    }
   
   



}
