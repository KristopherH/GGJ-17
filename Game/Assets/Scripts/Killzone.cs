using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			player.GetComponent<PlayerHealth>().lives = 0;
		} else if(other.tag == "Enemy"){
			Destroy(other.gameObject);
		}
	}
}
