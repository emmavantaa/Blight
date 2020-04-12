using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTo : MonoBehaviour {

	[SerializeField] private Transform Player;
	[SerializeField] private Transform SpawnPoint;

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Enter Trigger");
			Player.transform.position = new Vector3 (SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, 0);
		}
	}
}
