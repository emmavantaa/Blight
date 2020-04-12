using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarScript : MonoBehaviour {

    [SerializeField] private int maxhit;
    [SerializeField] private int timesHit;

    [SerializeField] private Transform Player;

    [SerializeField] private float Speed = 0.01f;
    [SerializeField] private float StoppingDis = 3f;

    [SerializeField] private GameObject Ham;
    [SerializeField] private GameObject PlayerPos;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timesHit = 0;
    }
    void Update()
    {
        EnemyAttack();
    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.CompareTag("Bullet"))
        {
            rb.isKinematic = true;
            timesHit++;

            if (timesHit >= maxhit)
            {
                rb.isKinematic = false;
                Speed = 0;
                anim.SetBool("isDead", true);          
                Instantiate(Ham, transform.position, Quaternion.identity);
                Destroy(gameObject, 0.1f);
            }
        }

        if (col.gameObject.CompareTag("Bullet2"))
        {
            rb.isKinematic = true;
            timesHit += 2;
            if (timesHit >= maxhit)
            {
                rb.isKinematic = false;
                Speed = 0;
                anim.SetBool("isDead", true);
                Destroy(gameObject, 0.1f);

            }
        }


        if (col.gameObject.CompareTag("Bomb"))
        {
            rb.isKinematic = true;
            timesHit += 2;
            if (timesHit >= maxhit)
            {
                rb.isKinematic = false;
                Speed = 0;
                anim.SetBool("isDead", true);
                Destroy(gameObject, 0.1f);
            }

        }

        else
        {
            rb.isKinematic = false;
        }


    }

    void EnemyAttack()
    {
        Vector3 theScale = transform.localScale;


        if (Vector2.Distance(transform.position, Player.position) < 7)
        {
            anim.SetBool("isWalking", true);


            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);

            if (Player.position.x > transform.position.x)
            {

                transform.localScale = new Vector3(-1, 1, 1);
            }

            else if (Player.position.x < transform.position.x)
            {

                transform.localScale = new Vector3(1, 1, 1);
            }


        }


        else
        {
            anim.SetBool("isWalking", false);
        }
    }

}