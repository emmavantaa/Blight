using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private Vector3 target;
    [SerializeField] private float speed = 2f;

    [SerializeField] private AudioSource Piu;

    [SerializeField] private Rigidbody2D rocketPrefab;
    [SerializeField] private Rigidbody2D granade;
    [SerializeField] private Transform barrelEnd;

    [SerializeField] private int maxAmmo;

	int AmmoCount;
    [SerializeField] private Text AmmocountText;
    [SerializeField] private Text NoAmmo;

    SpriteRenderer Weapon2;



    void Start () 
    {
		
		target = transform.position;
        Piu = GetComponent<AudioSource>();

	}

    void Update()
    {
       
        AmmoCount = maxAmmo;
        AmmoCount++;
        SetAmmoCountText();

        Rigidbody2D rocketInstantiate;
        if (maxAmmo >= 1)
        {
            NoAmmo.text = "".ToString();
        }

        if (maxAmmo <= 0)
        {
            Reload();
        }
        

        if (Input.GetMouseButtonDown(0))
        {

            if (maxAmmo >= 0)
            {
                Piu.Play();
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = Camera.main.transform.position.z;

                rocketInstantiate = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D; // Spawns rocketprefab from barrelEnd Position to rotation as a Rigidbody
                rocketInstantiate.AddForce(new Vector2(speed, speed));
                transform.eulerAngles = new Vector3(target.x * speed, target.y * speed, 0);
                rocketInstantiate.velocity = new Vector2(target.x * speed, target.y * speed); // Adds velocity from the position you stand at.
                maxAmmo -= 1; // Lose one ammo
                NoAmmo.text = "".ToString();
            }

            else if (maxAmmo <= 0)
            {
                NoAmmo.text = "RELOAD [E]";
            }

        }
    }
 
	void SetAmmoCountText ()
	{
		AmmocountText.text = AmmoCount.ToString ();
	}

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            maxAmmo += 100;
        }
    }

}
