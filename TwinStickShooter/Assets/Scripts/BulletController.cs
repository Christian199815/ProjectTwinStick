using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [Header("Bullet settings")]
    public float bulletSpeed = 7.0f;
    public AiCharacterScript Ai;

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
        if(other.tag == "Enemy")
        {

            other.gameObject.GetComponent<AiCharacterScript>().Health--;
            Destroy(gameObject);
        }
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Health--;
        }
    }
}
