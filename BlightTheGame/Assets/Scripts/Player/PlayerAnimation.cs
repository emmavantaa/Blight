using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator anim;
    [SerializeField] private AudioSource Walking;

    void Start () 
    {

		anim = GetComponentInChildren<Animator> ();
       
    }
	

	void Update () 
    {

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown(KeyCode.D))  
            {
            Walking.Play();
            anim.SetBool ("isWalking", true);
           
		}
        if  (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            Walking.Play();
            anim.SetBool("isWalking", true);
        }

        else {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                Walking.Stop();
                anim.SetBool("isWalking", false);
            }
		}

	}
}
