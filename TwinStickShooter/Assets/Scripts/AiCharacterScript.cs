using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCharacterScript : MonoBehaviour
{
    [SerializeField] private Transform Waypoint1;
    [SerializeField] private Transform Waypoint2;
    [SerializeField] private Transform Waypoint3;
    [SerializeField] private Transform Waypoint4;


    public int Health;
    public int DMG;
    [SerializeField] protected float Speed;

    //starts at a point in the game
    private void Start()
    {
        transform.position = Waypoint1.position;
    }



    private void Update()
    {
        Movement();
    }

    
    public void Movement()
    {
        if(transform.position == Waypoint1.position)
        {
            print(Waypoint1.position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint2.position, Speed * Time.deltaTime);
        }
        else if (transform.position == Waypoint2.position)
        {
            print(Waypoint2.position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint3.position, Speed * Time.deltaTime);
        }
        else if (transform.position == Waypoint3.position)
        {
            print(Waypoint3.position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint4.position, Speed * Time.deltaTime);
        }
        else if (transform.position == Waypoint4.position)
        {
            print(Waypoint4.position);
            transform.position = Vector3.MoveTowards(transform.position, Waypoint1.position, Speed * Time.deltaTime);
        }

    }

    




    

}
