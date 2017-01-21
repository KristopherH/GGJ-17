using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{    
    public  bool    grounded;
    private float   speed;
    private bool    face_left; //used later for animation maybe?
    private bool    face_right; //used later for animation maybe?
    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        face_left   = true;
        face_right  = false;
        grounded    = false;
        speed       = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Flip();
        Movement();
	}

    void Movement()
    {
        bool move_left = true;
        bool move_right = false;

        if(Input.GetKey(KeyCode.D))
        {
            face_left   = false;
            face_right  = true;

            move_left   = false;
            move_right  = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            face_left   = true;
            face_right  = false;

            move_left   = true;
            move_right  = false;
        }
        else
        {
            move_left   = false;
            move_right  = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (move_left)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if(move_right)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    void Flip()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 pushPoint = transform.position + new Vector3(-0.5f, 0, -0.5f);
            rb.AddForceAtPosition(new Vector3(0, 0, 900), pushPoint);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 pushPoint = transform.position + new Vector3(0.5f, 0, 0.5f);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Platform")
        {
            grounded = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Platform")
        {
            grounded = false;
        }
    }
}
