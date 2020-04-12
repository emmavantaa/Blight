using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag("Gun"))
		{
			this.gameObject.SetActive(false);
	}
}
}
