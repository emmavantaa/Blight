using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour {

	void Update () {
		Invoke("Hide", 1f);
	}

	void Hide()
	{
		this.gameObject.SetActive(false);
	}
}
