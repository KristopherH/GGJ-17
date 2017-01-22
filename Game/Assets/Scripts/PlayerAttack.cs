using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public float activeDoorAttackTime;
	private float doorTimer;
	enum STATE{
		COOKING,
		OPEN,
		INVINCIBLE
	}

	STATE playerState;

	[SerializeField] int collectedEnemyType;
	[SerializeField] int timer;

	[SerializeField] GameObject projectileBP;

	bool scored = true;
	GameObject door;

	// Use this for initialization
	void Start () {
		playerState = STATE.OPEN;
		GameObject.Find("DoorHinge").GetComponent<DoorController>().FinishCook();
		SoundsController.Instance.Play("GameStart");
		door = GameObject.Find ("Door");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<playerTimer>().cTimer <= 0){
			playerState = STATE.OPEN;
			if (!scored){
				SuccessfulCook();
				scored = true;
			}
		}
	}

//	IEnumerable DoorAttackTimer(){
//		if (doorTimer > 0.0f) {
//			doorTimer -= Time.deltaTime;
//			if (doorTimer <= 0.0f) 
//			{
//				door.tag = "Player";
//			}
//		}			
//		yield return null;
//	}

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
			GameObject.Find("DoorHinge").GetComponent<DoorController>().Eat();
			SoundsController.Instance.Play("MicrowaveDoorClose");
			switch(collectedEnemyType){
			case 0:
				GetComponent<playerTimer>().setCookingTimer(6.0f);
				SoundsController.Instance.Play("MicrowaveCook");
				scored = false;
				break;
			case 1:
				GetComponent<playerTimer>().setCookingTimer(3.0f);
				SoundsController.Instance.Play("MicrowaveCook");
				scored = false;
				break;
			case 2:
				//GetComponent<PlayerHealth>().respawn();
				//GetComponent<PlayerHealth>().lives = 0;
				break;
			}
			Destroy(enemy);
			break;
		case STATE.COOKING:
			//GetComponent<PlayerHealth>().respawn();
			GetComponent<PlayerHealth>().lives = 0;
			SoundsController.Instance.Play("MicrowaveBad");
			playerState = STATE.OPEN;
			break;
		case STATE.INVINCIBLE:
			Destroy(enemy);
			break;
		}
	}

	public float GetAttackPower()
	{
		return doorTimer;
	}

	void Shoot(){
		GameObject projectile;
		projectile = Instantiate(projectileBP);
		projectile.transform.position = transform.position;
		switch(GetComponent<Player_Controller>().ps){
		case Player_Controller.player_state.FACING_LEFT:
			projectile.GetComponent<ProjectileMovement>().direction = new Vector3(-10, 0, 0);
			break;
		case Player_Controller.player_state.FACING_RIGHT:
			projectile.GetComponent<ProjectileMovement>().direction = new Vector3(10, 0, 0);
			break;
		default:
			Destroy(projectile);
			break;
		}
	}

	void SuccessfulCook(){
		GameObject.Find("UI").GetComponent<Score>().increaseScore((collectedEnemyType+1)*10);
		GameObject.Find("DoorHinge").GetComponent<DoorController>().FinishCook();
		SoundsController.Instance.Play("PING");
		SoundsController.Instance.Play("MicrowaveDoorOpen");
		//				doorTimer = activeDoorAttackTime;
		//				door.tag = "DoorActive";
		//				StartCoroutine ("DoorAttackTimer");
		Shoot();

		if (GetComponent<Player_Controller>().p_standing_state == Player_Controller.player_standing_state.LAYING_DOWN){
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 600, 0));
			GetComponent<Player_Controller>().FaceUp();
		}
	}
}
