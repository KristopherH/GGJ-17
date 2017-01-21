using UnityEngine;
using System.Collections;

public class Player_Grounded : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.Find("Player");
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Platform")
        {
            player.GetComponent<Player_Movement>().grounded = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Platform")
        {
            player.GetComponent<Player_Movement>().grounded = false;
        }
    }
}
