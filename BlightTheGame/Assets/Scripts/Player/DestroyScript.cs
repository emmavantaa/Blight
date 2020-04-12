using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {


    void FixedUpdate () 
	{
		Destroy (gameObject, 0.40f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.CompareTag("Enemy"))
		{
           
			Destroy (gameObject,0.01f);


		}

		if (col.gameObject.CompareTag("DoorToBreak"))
		{
			Destroy (GameObject.FindWithTag("DoorToBreak"));

		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
