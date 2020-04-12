using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialTextScript : MonoBehaviour {

	[SerializeField] private bool isImgOn;
	[SerializeField] private Image img;
	[SerializeField] private Image img2;

	public Transform Player;


	void Start(){
		img2.enabled =false;
		img.enabled =false;
		isImgOn = false;
	}

	 void Update(){

		viewPicture ();

	}

	void viewPicture() 
	{

		if (Input.GetKeyDown (KeyCode.E)) 
		{

			if (Vector2.Distance (transform.position, Player.position) < 2) 
			{
				img.enabled = true;
				img2.enabled =false;
				isImgOn = true;
				Debug.Log ("Image is on");
			} 


		}

		if (Vector2.Distance (transform.position, Player.position) > 0.5) 
		{
			img.enabled =false;
			img2.enabled =false;
			isImgOn = false;
		}

		if  (Vector2.Distance (transform.position, Player.position) < 0.5 ) 
		{
			img2.enabled =true;
			isImgOn = false;
		}
	}
}
