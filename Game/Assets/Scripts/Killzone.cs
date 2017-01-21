using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player_Master"){
			other.gameObject.GetComponent<PlayerHealth>().respawn();
		} else if(other.tag == "Enemy"){
			Destroy(other.gameObject);
		}
	}
}
