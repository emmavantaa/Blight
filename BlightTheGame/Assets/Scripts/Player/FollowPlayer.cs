using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 Offset;
    
    void Update () 
    {
		transform.position = new Vector3 (target.position.x, target.position.y, 0)+ Offset; 
    }

}
