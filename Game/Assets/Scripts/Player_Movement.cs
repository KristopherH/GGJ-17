using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{    
    public  bool    grounded;
    private float   speed;
    private bool    face_left; //used later for animation maybe?
    private bool    face_right; //used later for animation maybe?
    public bool    flipped_left;
    public bool    flipped_right;
    public Animator player_animator;
    private GameObject mover;

    // Use this for initialization
    void Awake ()
    {
        face_left       = true;
        face_right      = false;
        flipped_left    = false;
        flipped_right   = false;
        grounded        = false;
        speed           = 10;
        player_animator = GameObject.Find("Player_Manager").GetComponent<Animator>();
        mover = GameObject.Find("Player_Mover");
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

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            mover.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (move_left)
        {
            mover.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if(move_right)
        {
            mover.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    void Flip()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !flipped_left)
        {
            if (flipped_right)
            {
                flipped_right = false;
                flipped_left = false;
                player_animator.Play("Flip_Right_To_Left");
            }
            else
            {
                flipped_left = true;
                player_animator.Play("Flip_Left");
            }
            Debug.Log("Tried to run Flip_Left");
        }

        if (Input.GetKeyDown(KeyCode.E) && !flipped_right)
        {
            if (flipped_left)
            {
                flipped_left = false;
                flipped_right = false;
                player_animator.Play("Flip_Left_To_Right");
            }
            else
            {
                flipped_right = true;
                player_animator.Play("Flip_Right");
            }
            Debug.Log("Tried to run Flip_Right");
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
