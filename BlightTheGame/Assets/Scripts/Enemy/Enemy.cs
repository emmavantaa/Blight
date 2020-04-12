using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private CameraShake Camshake;

    [SerializeField] private Transform Player;
    [SerializeField] private GameObject PlayerPos;
    [SerializeField] private Rigidbody2D rb;


    [SerializeField] private int maxhit;
    [SerializeField] private float Speed= 0.01f;
    [SerializeField] private float StoppingDis = 3f;

	private int timesHit;
	private Vector2 velocity;
	private Animator anim;


	void Start()
	{
		
		anim = GetComponent<Animator> ();
    
        
		timesHit = 0;
	}
	void Update(){
		
		EnemyAttack ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{


		if (col.gameObject.CompareTag("Bullet") )
		{
            rb.isKinematic = true;
            timesHit++;
            

            if (timesHit >= maxhit) {

                EnemyShooter.maxSpawns -= 1;
                rb.isKinematic = false;
                Speed = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("isDead", true);
                Destroy(gameObject, 0.4f);
            }
		}

        if (col.gameObject.CompareTag("Bullet2"))
        {
            EnemyShooter.maxSpawns -= 1;
            rb.isKinematic = true;
            timesHit += 2;
            if (timesHit >= maxhit)
            {
                rb.isKinematic = false;
                Speed = 0;
                rb.isKinematic = true;
                anim.SetBool("isDead", true);
                Destroy(gameObject, 0.4f);
            }
        }


        if (col.gameObject.CompareTag("Bomb"))
        {
            EnemyShooter.maxSpawns -= 1;
            rb.isKinematic = true;
            timesHit+= 2;
            if (timesHit >= maxhit)
            {
                rb.isKinematic = false;
                Speed = 0;
                rb.isKinematic = true;
                anim.SetBool("isDead", true);
                Destroy(gameObject, 0.4f);
            }
        }
        else
        {
            rb.isKinematic = false;
        }	
	}

	void EnemyAttack(){

		Vector3 theScale = transform.localScale;

		if (Vector2.Distance (transform.position, Player.position) < 7) {
			anim.SetBool ("isWalking", true);
			transform.position = Vector2.MoveTowards (transform.position, Player.position, Speed * Time.deltaTime);

			if (Player.position.x > transform.position.x) {
				
				transform.localScale = new Vector3(-1,1,1);
			}

			else if (Player.position.x < transform.position.x) {
				
				transform.localScale = new Vector3(1,1,1);
			}
		} 
		else 
		{
			anim.SetBool ("isWalking", false);
		}
	}
		
}
