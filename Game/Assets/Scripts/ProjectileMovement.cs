using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public Vector3 direction;
	public int life;

	// Use this for initialization
	void Start () {
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction*Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy"){
			Destroy(other.gameObject);
			life--;
		}
	}
}
