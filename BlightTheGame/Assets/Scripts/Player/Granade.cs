using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Granade : MonoBehaviour {

    [SerializeField] private float speed = 2f;

    [SerializeField] private Rigidbody2D granade;

    [SerializeField] private int maxAmmo;
    [SerializeField] private Transform player;
    [SerializeField] private AudioSource Boom;
    
    [Header("UI")]
    [SerializeField] private Text GrenadecountText;


    int GrenadeCount;
    private Vector3 target;

    void Start () 
    {
        target = transform.position;
        Boom= GetComponent<AudioSource>();
    }
	

	void Update () 
    {
        GrenadeCount = maxAmmo;
        GrenadeCount++;
        SetGrenadeCountText();
        Rigidbody2D grenadeInstantiate;
        if (maxAmmo >= 0)
        {

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = Camera.main.transform.position.z;

            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (maxAmmo >= 0)
                {
                    Boom.Play();

                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = Camera.main.transform.position.z;

                    // Bullet Shoot
                    grenadeInstantiate = Instantiate(granade, player.position, player.rotation) as Rigidbody2D; 
                    grenadeInstantiate.AddForce(new Vector2(speed, speed));
                    transform.eulerAngles = new Vector3(target.x * speed, target.y * speed, 0);
                    maxAmmo -= 1; 
                    GrenadeCount++;
                }

                else if (maxAmmo <= 0)
                {
                    Debug.Log("No Grenades left"); 
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PickupGrenade"))
        {
            col.gameObject.SetActive(false);
            GrenadeCount++;
            GrenadeCount += 10;
            maxAmmo += 10;
            SetGrenadeCountText();
        }
    }

    void SetGrenadeCountText()
    {
        GrenadecountText.text =  GrenadeCount.ToString();
    }
}
