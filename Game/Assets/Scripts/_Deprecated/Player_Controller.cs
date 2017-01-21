using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

    enum player_state
    {
        FACING_LEFT,
        FACING_RIGHT,
        FACING_FORWARD,
        FACING_DOWN
    };

    public float speed;
    public bool player_grounded;

    private Animator player_ani;
    private player_state ps;
    private bool can_animate;
    private float ani_run_time = 0.3f;

    [SerializeField]
    GameObject player;

	void Awake ()
    {
        speed = 5.0f;
        player_grounded = false;
        player_ani = GetComponent<Animator>();
        ps = player_state.FACING_FORWARD;
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
                ani_run_time = 0.5f;
                can_animate = true;
            }
            else
            {
                ani_run_time -= Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.A)) //Left
        { 
            if (ps == player_state.FACING_FORWARD && can_animate)
            {
                player_ani.Play("Forward_To_Left");
                ps = player_state.FACING_LEFT;
                can_animate = false;
            }
            else if (ps == player_state.FACING_RIGHT && can_animate)
            {
                player_ani.Play("Right_To_Forward");
                ps = player_state.FACING_FORWARD;
                can_animate = false;
            }
            else if(can_animate)
            {
                this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        else if(Input.GetKey(KeyCode.D)) //Right
        {
            if (ps == player_state.FACING_FORWARD && can_animate)
            {
                player_ani.Play("Forward_To_Right");
                ps = player_state.FACING_RIGHT;
                can_animate = false;
            }
            else if (ps == player_state.FACING_LEFT && can_animate)
            {
                player_ani.Play("Left_To_Forward");
                ps = player_state.FACING_FORWARD;
                can_animate = false;
            }
            else if(can_animate)
            {
                this.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.W) && can_animate) //Up
        {
            Debug.Log("W Pressed");
            if (ps == player_state.FACING_FORWARD)
            {
                Debug.Log("Trying to face forward");
                player_ani.Play("Down_To_Forward");
                ps = player_state.FACING_FORWARD;
                can_animate = false;
            }
            else if (ps == player_state.FACING_LEFT)
            {
                Debug.Log("Trying to face Left");
                player_ani.Play("Down_To_Left");
                ps = player_state.FACING_LEFT;
                can_animate = false;
            }
            else if (ps == player_state.FACING_RIGHT)
            {
                Debug.Log("Trying to face Right");
                player_ani.Play("Down_To_Right");
                ps = player_state.FACING_RIGHT;
                can_animate = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S) && can_animate) //Down
        {
            if (ps == player_state.FACING_FORWARD)
            {
                player_ani.Play("Forward_To_Down");
                can_animate = false;
            }
            else if (ps == player_state.FACING_LEFT)
            {
                player_ani.Play("Left_To_Down");
                can_animate = false;
            }
            else if (ps == player_state.FACING_RIGHT)
            {
                player_ani.Play("Right_To_Down");
                can_animate = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {

        }
        else if(Input.GetKeyUp(KeyCode.S) && can_animate)
        {
           
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