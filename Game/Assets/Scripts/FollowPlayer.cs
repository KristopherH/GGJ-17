using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	[SerializeField] GameObject target;
	[SerializeField] float maxDistFromPlayer;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player_Mover");
	}
	
	// Update is called once per frame
	void Update () {
		if (maxDistFromPlayer <= Mathf.Abs(transform.position.x - target.transform.position.x)){
			transform.position = Vector3.Lerp(transform.position, 
												new Vector3(target.transform.position.x, 
															transform.position.y, 
															transform.position.z), 
												Time.deltaTime);
		}
	}
}
