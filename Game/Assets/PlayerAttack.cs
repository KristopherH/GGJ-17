using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	enum STATE{
		COOKING,
		OPEN,
		INVINCIBLE,
		BLOCKED
	}

	[SerializeField] STATE playerState;
	[SerializeField] STATE lastState;

	[SerializeField] int collectedEnemyType;

	// Use this for initialization
	void Start () {
		playerState = STATE.OPEN;
		lastState = playerState;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerHealth>().invincibility == 0 && playerState == STATE.INVINCIBLE){
			lastState = playerState;
			playerState = STATE.OPEN;
		}
	}
	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == "Enemy"){
			switch(playerState){
			case STATE.OPEN:
				collectedEnemyType = collision.gameObject.GetComponent<EnemyController>().type;
				Destroy(collision.gameObject);
				lastState = playerState;
				playerState = STATE.COOKING;
				break;
			case STATE.COOKING:
				GetComponent<PlayerHealth>().respawn();
				lastState = playerState;
				playerState = STATE.INVINCIBLE;
				break;
			case STATE.INVINCIBLE:
				Destroy(collision.gameObject);
				break;
			case STATE.BLOCKED:
				GetComponent<PlayerHealth>().respawn();
				lastState = playerState;
				playerState = STATE.INVINCIBLE;
				break;
			}
		}
	}
}
