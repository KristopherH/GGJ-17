using UnityEngine;
using System.Collections;

public class EnemyTriggerCollider : MonoBehaviour {

	public bool grounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Platform"){
			grounded = true;
		}
	}
		
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Platform"){
			grounded = false;
		}
	}
}
