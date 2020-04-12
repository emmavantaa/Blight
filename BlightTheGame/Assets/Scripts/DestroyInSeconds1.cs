using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds1 : MonoBehaviour {

    public float time = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, time);
	}
}
