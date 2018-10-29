using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarBreak : MonoBehaviour {

   // private Rigidbody rb;
	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (transform.up.y < .3)
        {
            Destroy(gameObject, 5);
        }


    }
}
