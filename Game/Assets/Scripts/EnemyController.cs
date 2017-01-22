using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int type = 1;

	public Vector3 moveDirection;
	public float speed;
    public float life_time;

    private bool ignore_platform_collider;

    [SerializeField] bool grounded = false;

	// Use this for initialization
	void Start () {
		if (speed == 999)
		speed = 0f; 
		else 
		speed = Random.Range(0.03f, 0.08f);

        ignore_platform_collider = false;
        life_time = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
		grounded = gameObject.GetComponentInChildren<EnemyTriggerCollider>().grounded;
		if (grounded && !GameObject.Find("Main Camera").GetComponent<pauseMenuScript1>().paused){
			transform.position+=(moveDirection*speed);
		}

        life_time -= Time.deltaTime;
        if (life_time <= 0)
            ignore_platform_collider = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlatformLimit" && !ignore_platform_collider){
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
