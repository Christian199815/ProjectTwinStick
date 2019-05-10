using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Rigidbody rb;

    [Header("Bullet settings")]
    public float bulletSpeed = 7.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update () {
		rb.velocity = transform.forward * bulletSpeed;
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
