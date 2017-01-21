using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	enum STATE{
		COOKING,
		OPEN,
		INVINCIBLE
	}

	STATE playerState;

	[SerializeField] int collectedEnemyType;
	[SerializeField] int timer;

	// Use this for initialization
	void Start () {
		playerState = STATE.OPEN;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerHealth>().invincibility > 0){
			playerState = STATE.INVINCIBLE;
		}
		if (playerState == STATE.COOKING && timer > 0){
			timer--;
		} else if (timer == 0){
			playerState = STATE.OPEN;
		}
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == "Enemy"){
			EnemyCollision(collision.gameObject);
		}
	}

	void EnemyCollision(GameObject enemy){
		switch(playerState){
		case STATE.OPEN:
			collectedEnemyType = enemy.GetComponent<EnemyController>().type;
			playerState = STATE.COOKING;
			switch(collectedEnemyType){
			case 0:
				timer = 100;
				break;
			case 1:
				timer = 200;
				break;
			case 2:
				GetComponent<PlayerHealth>().respawn();
				break;
			}
			break;
		case STATE.COOKING:
			GetComponent<PlayerHealth>().respawn();
			playerState = STATE.INVINCIBLE;
			break;
		case STATE.INVINCIBLE:
			Destroy(enemy);
			break;
		}
	}
	
	void openDoor(){

	}
}
