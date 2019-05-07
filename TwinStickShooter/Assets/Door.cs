using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
        rb.centerOfMass = transform.position;
	}
	
	void Update () {
		
	}
}
