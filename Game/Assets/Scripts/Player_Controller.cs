using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

    public enum player_state
    {
        FACING_LEFT,
        FACING_RIGHT,
        FACING_FORWARD
    };
    public enum player_standing_state
    {
        STANDING_UP,
        LAYING_DOWN
    };

    public float speed;
    public bool player_grounded;

    public Animator player_ani;
    public player_state ps;
    public player_standing_state p_standing_state;
    public bool can_animate;
    public float ani_run_time = 0.1f;

    private bool s_held = false;

    [SerializeField]
    GameObject player;

	void Awake ()
    {
        speed = 10.0f;
        player_grounded = false;
        player_ani = GetComponent<Animator>();
        ps = player_state.FACING_FORWARD;
        p_standing_state = player_standing_state.STANDING_UP;
        can_animate = true;
	}
	
	void Update ()
    {
        Movement();
	}


    void Movement() 
    {
        if(!can_animate)
        {
            if(ani_run_time <= 0)
            {
                ani_run_time = 0.1f;
                can_animate = true;
            }
            else
            {
                ani_run_time -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetButtonDown("X/S") && !s_held)) s_held = true;
        else if (Input.GetKeyUp(KeyCode.S) || (Input.GetButtonUp("X/S") && s_held)) s_held = false;
        else if (Input.GetKey(KeyCode.S) || Input.GetButton("X/S")) s_held = true;
        else if (s_held) s_held = false;
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0) //Left
        {
            if (ps == player_state.FACING_FORWARD && can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                player_ani.Play("Forward_To_Left");
                ps = player_state.FACING_LEFT;
                can_animate = false;
            }
            else if (ps == player_state.FACING_RIGHT && can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                player_ani.Play("Right_To_Forward");
                ps = player_state.FACING_FORWARD;
                can_animate = false;
            }
            else if (can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0) //Right
        {
            if (ps == player_state.FACING_FORWARD && can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                player_ani.Play("Forward_To_Right");
                ps = player_state.FACING_RIGHT;
                can_animate = false;
            }
            else if (ps == player_state.FACING_LEFT && can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                player_ani.Play("Left_To_Forward");
                ps = player_state.FACING_FORWARD;
                can_animate = false;
            }
            else if (can_animate && p_standing_state == player_standing_state.STANDING_UP)
            {
                this.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }

        if (s_held && can_animate && p_standing_state == player_standing_state.STANDING_UP) //Down
        {
            if (ps == player_state.FACING_FORWARD)
            {
                player_ani.Play("Forward_To_Down");
                p_standing_state = player_standing_state.LAYING_DOWN;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
            else if (ps == player_state.FACING_LEFT)
            {
                player_ani.Play("Left_To_Down");
                p_standing_state = player_standing_state.LAYING_DOWN;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
            else if (ps == player_state.FACING_RIGHT)
            {
                player_ani.Play("Right_To_Down");
                p_standing_state = player_standing_state.LAYING_DOWN;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
        }
        else if (!s_held && can_animate && p_standing_state == player_standing_state.LAYING_DOWN) //Up
        {
            Debug.Log("S Not Pressed");
            if (ps == player_state.FACING_FORWARD)
            {
                Debug.Log("Trying to face forward");
                player_ani.Play("Down_To_Forward");
                ps = player_state.FACING_FORWARD;
                p_standing_state = player_standing_state.STANDING_UP;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
            else if (ps == player_state.FACING_LEFT)
            {
                Debug.Log("Trying to face Left");
                player_ani.Play("Down_To_Left");
                ps = player_state.FACING_LEFT;
                p_standing_state = player_standing_state.STANDING_UP;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
            else if (ps == player_state.FACING_RIGHT)
            {
                Debug.Log("Trying to face Right");
                player_ani.Play("Down_To_Right");
                ps = player_state.FACING_RIGHT;
                p_standing_state = player_standing_state.STANDING_UP;
                can_animate = false;
				SoundsController.Instance.Play("MicrowaveFlip");
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetAxis("A/X") == 1) && player_grounded)
        {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 150, 0));

            //this.transform.Translate(this.transform.position + new Vector3(0, 1, 0));
        }
    }




    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Platform")
        {
            player_grounded = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Platform")
        {
            player_grounded = false;
        }
    }

    public void FaceUp()
    {
        if (ps == player_state.FACING_FORWARD)
        {
            Debug.Log("Trying to face forward");
            player_ani.Play("Down_To_Forward");
            ps = player_state.FACING_FORWARD;
            p_standing_state = player_standing_state.STANDING_UP;
            can_animate = false;
			SoundsController.Instance.Play("MicrowaveFlip");
        }
        else if (ps == player_state.FACING_LEFT)
        {
            Debug.Log("Trying to face Left");
            player_ani.Play("Down_To_Left");
            ps = player_state.FACING_LEFT;
            p_standing_state = player_standing_state.STANDING_UP;
            can_animate = false;
			SoundsController.Instance.Play("MicrowaveFlip");
        }
        else if (ps == player_state.FACING_RIGHT)
        {
            Debug.Log("Trying to face Right");
            player_ani.Play("Down_To_Right");
            ps = player_state.FACING_RIGHT;
            p_standing_state = player_standing_state.STANDING_UP;
            can_animate = false;
			SoundsController.Instance.Play("MicrowaveFlip");
        }
    }
}








//bool rotation_complete = false;
//Debug.Log("Tried to move left");
//while (!rotation_complete)
//{
//    player.transform.Rotate(0, -speed * Time.deltaTime, 0);
//    if (player.transform.eulerAngles.y >= 90)
//    {
//        player.transform.eulerAngles = new Vector3(
//            transform.eulerAngles.x, 90, transform.eulerAngles.z);
//        rotation_complete = true;
//    }
//    Debug.Log("HELP");
//}