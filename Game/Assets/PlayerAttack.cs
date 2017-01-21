using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	enum STATE{
		COOKING,
		OPEN,
		INVINCIBLE
	}

	STATE playerState;

	[SerializeField] GameObject collectedEnemy;

	// Use this for initialization
	void Start () {
		playerState = STATE.OPEN;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerHealth>().invincibility > 0){
			playerState = STATE.INVINCIBLE;
		}
	}
	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == "Enemy"){
			switch(playerState){
			case STATE.OPEN:
				collectedEnemy = collision.gameObject;
				playerState = STATE.COOKING;
				break;
			case STATE.COOKING:
				GetComponent<PlayerHealth>().respawn();
				playerState = STATE.INVINCIBLE;
				break;
			case STATE.INVINCIBLE:
				Destroy(collision.gameObject);
				break;
			}
		}
	}
}
