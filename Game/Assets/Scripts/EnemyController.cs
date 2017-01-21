using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int type = 1;

	public Vector3 moveDirection;
	public float speed;

	[SerializeField] bool grounded = false;

	// Use this for initialization
	void Start () {
		speed = Random.Range(0.03f, 0.08f);
	}
	
	// Update is called once per frame
	void Update () {
		grounded = gameObject.GetComponentInChildren<EnemyTriggerCollider>().grounded;
		if (grounded && !GameObject.Find("Main Camera").GetComponent<pauseMenuScript1>().paused){
			transform.position+=(moveDirection*speed);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlatformLimit"){
			//Debug.Log("LIMIT");
			moveDirection = -moveDirection;
		}
		if (other.tag == "DoorActive") {
			GetHit ();
		}
	}

	void GetHit()
	{
		Debug.Log ("Enemy hit");
	}

}
