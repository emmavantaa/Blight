using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeadBody : MonoBehaviour {

    [SerializeField] private Transform Player;
    [SerializeField] private Text DeathText;

    void Start () {
        DeathText.enabled = false;
    }
	

	void Update () {
        DeadMan();
	}

    void DeadMan()
    {
        if (Vector2.Distance(transform.position, Player.position) < 2)
        {
            DeathText.enabled = true;
            DeathTextShow();
        }

        else
        {
            DeathText.enabled = false;
        }
        }

    void DeathTextShow()
    {
       
            DeathText.text = "Poor Jimmy boy.. " + "[E]";
        
        
        if (Input.GetKey(KeyCode.E))
        {
            DeathText.text = "Looks like he lost his weapon somewhere";
        }

    }
}
