using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	[SerializeField] private Vector3 Pivot;


	void FixedUpdate () 
	{
        FaceMouse();
	}

	void FaceMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		Quaternion rot = Quaternion.LookRotation (transform.position.normalized - mousePos,Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0,0, transform.eulerAngles.z);
	}

}
