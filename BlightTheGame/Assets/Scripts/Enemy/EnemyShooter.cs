using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {


    [Header("EnemySpawn")]
    private float timeBtwShots;
    private float timeBtwShotsSwish;

    [SerializeField] private CameraShake Camshake;

    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject Attack;

    [Header("Health")]
    [SerializeField] private int maxhit;
    private int timesHit;

    [Header("Animation")]
    private Animator anim;

    public static int maxSpawns;


    void Start()
    {
        anim = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
        timesHit = 0;
        maxSpawns = 0;
        
    }

    void Update()
    {
        anim.SetBool("Idle", true);

        if (maxSpawns != 10)
        {
            
            anim.SetBool("Spawner", true);
            SpawnSmallEnemies();
        }

        if (maxSpawns == 10)
        {
            anim.SetBool("Idle", true);
            
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.CompareTag("Bullet"))
        {
           
            anim.SetBool("isHurt", true);
            timesHit++;

            if (timesHit >= maxhit)
            {
                Destroy(gameObject);
            }
        }

        if (col.gameObject.CompareTag("Bullet2"))
        {
            timesHit += 2;
            anim.SetBool("isHurt", true);

            if (timesHit >= maxhit)
            {
                Destroy(gameObject);
            }
        }


    }

    void SpawnSmallEnemies()
    {

        if (timeBtwShots <= 1f)
        {
            maxSpawns += 1;
            anim.SetBool("Spawner", true);
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }


        if (timeBtwShotsSwish <= 0)
        {
            
            Instantiate(Attack, transform.position, Quaternion.identity);
            timeBtwShotsSwish = startTimeBtwShots;
        }

        else
        {

            timeBtwShots -= Time.deltaTime;

        }
    }
    
    }
		
