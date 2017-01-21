using UnityEngine;
using System.Collections;

public class LivesDisplay : MonoBehaviour {
	public int lives;
	// Use this for initialization
	void Start () {
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		lives = GetComponentInParent<PlayerHealth>().lives;
		switch(lives){
		case 2:
			gameObject.transform.FindChild("Heart3").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case 1:
			gameObject.transform.FindChild("Heart2").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.FindChild("Heart3").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case 0:
			gameObject.transform.FindChild("Heart1").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.FindChild("Heart2").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.FindChild("Heart3").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			break;
		}
	}
}
