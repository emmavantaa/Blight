using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Animation/audio test
    private Animator anim;
     private Rigidbody2D rb;
    [SerializeField] private AudioSource Walking;


    [SerializeField] private Text countText;
    [SerializeField] private int Count;

    [SerializeField] private Text HealthText;
	int HealthCount;

    [SerializeField] private float wspeedH = 0f;
    private int walkingDir;
    [SerializeField] private float dashSpeed;


    [SerializeField] private Transform PlayerPos;


    [SerializeField] private int maxhit;
	private int timesHit;

    bool EnableWeapon;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Gun2;

    void Start () 
    {

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
		Count = 0;
		SetCountText ();
		timesHit = 0;

	}
	
	void Update ()
	{

		HealthCount = maxhit;

		SetHealthText ();

		Vector3 theScale = transform.localScale;

        if (Input.GetKey (KeyCode.D))
        {
            IsWalking();

            transform.position += new Vector3 (wspeedH * Time.deltaTime,0,0);

			
			theScale.x = 0.5f;
			transform.localScale = theScale;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.right * dashSpeed;

            }
            else { rb.velocity = Vector2.zero; }

        }

		if (Input.GetKey (KeyCode.A))
        {
            IsWalking();

            transform.position -= new Vector3 (wspeedH * Time.deltaTime,0,0);
			

			theScale.x = -0.5f;
			transform.localScale = theScale;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.left * dashSpeed;

            }
            else { rb.velocity = Vector2.zero; }
        }

		if (Input.GetKey (KeyCode.W)) 
		{
            IsWalking();
            transform.position += new Vector3 (0, wspeedH * Time.deltaTime, 0);
            
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.up * dashSpeed;

            }
            else { rb.velocity = Vector2.zero; }

        }

		if (Input.GetKey (KeyCode.S)) {
            IsWalking();
            transform.position -= new Vector3 (0, wspeedH * Time.deltaTime, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.down * dashSpeed;

            }
            else { rb.velocity = Vector2.zero; }

        }

        else
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                IsNotWalking();
            }
        }



    }

    void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Pickup")) 
        {
			col.gameObject.SetActive (false);
			Count++;
			SetCountText ();
		}

        if (col.gameObject.CompareTag("Health"))
        {
            col.gameObject.SetActive(false);
            
            maxhit += 10;
            HealthCount++;
            SetHealthText();

        }

        else if (col.gameObject.CompareTag("Treasure"))
        {
			col.gameObject.SetActive (false);
			Count += 10;
			SetCountText ();
		}

        if (col.gameObject.CompareTag("Gun2"))
        {
            Gun.SetActive(false);
            Gun2.SetActive(true);
        }

        }
 

    void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.CompareTag("Enemy"))
		{
            anim.SetBool("GettingHurt", true);
            HealthCount++;
			SetHealthText ();
			maxhit -= 1;

			timesHit++;

			if (timesHit >= maxhit) {
				maxhit -= 1;

				if (maxhit == 0)
				{
					Debug.Log ("Hits Enemy");
                    PlayerPos.transform.position = new Vector3(0, 0, 0);
                    maxhit += 10;
					
				}
                else if (maxhit ==-1)
                {
                    PlayerPos.transform.position = new Vector3(0, 0, 0);
                    maxhit += 10;
                }

            }
	
		}

        else if(col.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("GettingHurt", false);
        }

            if (col.gameObject.CompareTag("EnemyBullet"))
		{

			HealthCount++;
			SetHealthText ();
			maxhit -= 1;

			timesHit++;

			if (timesHit >= maxhit) {
				maxhit -= 1;

				if (maxhit == 0)
				{
					Destroy (gameObject);
				}

			}

		}

	}
		
    void IsWalking()
    {
        Walking.Play();
        anim.SetBool("isWalking", true);
        anim.SetBool("GettingHurt", false);

    }

    void IsNotWalking()
    {
        Walking.Stop();
        anim.SetBool("isWalking", false);
        anim.SetBool("GettingHurt", false);
    }

    

	 void SetCountText()
	{
		countText.text = Count.ToString ();
	}

	void SetHealthText()
	{
		HealthText.text = HealthCount.ToString ();

	}
}