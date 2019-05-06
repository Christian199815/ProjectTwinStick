using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [Header("Bullet settings")]
    public float bulletSpeed = 7.0f;

    private void Update () {
		transform.position += transform.forward * bulletSpeed;
	}

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);

        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
