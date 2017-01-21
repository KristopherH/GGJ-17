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
		if (other.tag == "Player"){
			other.gameObject.GetComponent<PlayerHealth>().respawn();
		} else {
			Destroy(other.gameObject);
		}
	}
}
