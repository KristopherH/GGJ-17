using UnityEngine;
using System.Collections;

public class Vibrate : MonoBehaviour {

	[SerializeField]
	float staggerAmount;
	[SerializeField]
	float staggerDelay;
	float staggerCounter;

	void OnEnable()
	{
		staggerCounter = staggerDelay;
		staggerCounter = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		staggerCounter -= Time.deltaTime;
		if (staggerCounter > 0.0f) {
			Debug.Log ("NSDFKFEDFEFVJ!");
			return;
		}
		staggerCounter = staggerDelay;
		transform.parent.gameObject.transform.position = new Vector3 (
			transform.parent.gameObject.transform.position.x,
			transform.parent.gameObject.transform.position.y + staggerAmount,
			transform.parent.gameObject.transform.position.z);
		staggerAmount *= -1;
	}
}
