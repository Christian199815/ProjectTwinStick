using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Rigidbody rb;
    private HingeJoint hj;
    private JointSpring js;

    public DoorState state;
    private float aOld;

    private float startAngle;

    private float stateTimer;

    public float closeDelay;
    public float closeStrength;
    private float closingDir;

	void Start () {
		rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
        js = hj.spring;

        startAngle = transform.eulerAngles.y.Round();
        aOld = startAngle;

        state = DoorState.closed;
	}
	
	void Update () {
		float a = transform.eulerAngles.y.Round();

        switch(state)
        {
            case DoorState.closed:
                js.spring = 0;

                if(a != aOld)
                {
                    stateTimer = 0;
                    state = DoorState.opening;
                }
                break;
            
            case DoorState.opening:
                js.spring = 0;

                if(a == aOld)
                {
                    stateTimer += Time.deltaTime;

                    if(stateTimer > closeDelay)
                    {
                        stateTimer = 0;
                        state = DoorState.closing;
                    }
                }
                else
                {
                    stateTimer = 0;
                }
                break;

            case DoorState.closing:
                js.spring = closeStrength;

                float curDir = (a - aOld == 0) ? 0 : Mathf.Sign(a - aOld);

                if(a == aOld)
                {
                    stateTimer += Time.deltaTime;

                    if(stateTimer > .05f)
                    {
                        state = DoorState.closed;
                    }
                }
                else
                {
                    stateTimer = 0;
                }

                closingDir = curDir;
                break;
        }

        if(transform.eulerAngles.y > startAngle + 90)
        {
            transform.eulerAngles = new Vector3(0, startAngle, 0);
            rb.velocity = Vector3.zero;

            print(a + "," + startAngle);
        }

        if (transform.eulerAngles.y < startAngle - 90)
        {
            print(a + "," + startAngle);

            transform.eulerAngles = new Vector3(0, startAngle - 90, 0);
            rb.velocity = Vector3.zero;
        }


        hj.spring = js;
        aOld = a;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            state = DoorState.opening;
            js.spring = 0;
            hj.spring = js;
        }
    }

    public enum DoorState
    {
        closed = 0,
        opening,
        closing
    }
}
