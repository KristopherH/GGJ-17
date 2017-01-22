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

	[SerializeField] STATE playerState;

	[SerializeField] int collectedEnemyType;
	[SerializeField] float invincibilityTimer;
	[SerializeField] GameObject projectileBP;
	[SerializeField] GameObject spoonMode;

	[SerializeField] bool scored;
	GameObject door;

	// Use this for initialization
	void Start () {
		scored = true;
		playerState = STATE.OPEN;
		GameObject.Find("DoorHinge").GetComponent<DoorController>().FinishCook();
		SoundsController.Instance.Play("GameStart");
		door = GameObject.Find ("Door");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerHealth>().lives > 0){
			if (GetComponent<playerTimer>().cTimer <= 0){
				playerState = STATE.OPEN;
				if (!scored){
					SuccessfulCook();
					scored = true;
				}
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
		if (GetComponent<PlayerHealth>().lives > 0){
			if (collision.gameObject.layer == 20) {
				EnemyCollision (collision.gameObject);
			} else if (collision.gameObject.tag == "Spoon") {
				SpoonCollision ();
			}
		}
	}

	void EnemyCollision(GameObject enemy){
		switch(playerState){
		case STATE.COOKING:
			//GetComponent<PlayerHealth>().respawn();
			GetComponent<PlayerHealth>().lives = 0;
			SoundsController.Instance.Play("MicrowaveBad");
			SoundsController.Instance.StopLoop("MicrowaveCook");
			Destroy(enemy);
			playerState = STATE.OPEN;
			Debug.Log("HIT while cooking");
			break;
		case STATE.OPEN:
			CollectEnemy(enemy);
			//InvincibleFor(0.5f);
			Debug.Log("Start cooking");
			Destroy(enemy);
			break;
		case STATE.INVINCIBLE:
			SoundsController.Instance.Play("Gulp");
			Score.Instance.increaseScore(5);
			Destroy(enemy);
			break;
		}
	}

	void InvincibleFor(float seconds){
		SetInvincible(true);
		invincibilityTimer = seconds;
		StartCoroutine("InvincibleTimer");
	}

	IEnumerable InvincibleTimer(){
		yield return new WaitForSeconds(invincibilityTimer);
		SetInvincible(false);
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
		SpoonSpawner.Instance.RegisterCook ();
		GameObject.Find("UI").GetComponent<Score>().increaseScore((collectedEnemyType+1)*10);
		GameObject.Find("DoorHinge").GetComponent<DoorController>().FinishCook();
		SoundsController.Instance.Play("PING");
		SoundsController.Instance.Play("MicrowaveDoorOpen");
		SoundsController.Instance.StopLoop("MicrowaveCook");
		//				doorTimer = activeDoorAttackTime;
		//				door.tag = "DoorActive";
		//				StartCoroutine ("DoorAttackTimer");
		if (collectedEnemyType == 0){
			Shoot();
		}

		if (GetComponent<Player_Controller>().p_standing_state == Player_Controller.player_standing_state.LAYING_DOWN){
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 600, 0));
			GetComponent<Player_Controller>().FaceUp();
		}
	}

	void SpoonCollision()
	{
		spoonMode.SetActive(true);
		playerState = STATE.INVINCIBLE;
		GameObject.Find("DoorHinge").GetComponent<DoorController>().Eat();
		SoundsController.Instance.Play("MicrowaveDoorClose");
		GetComponent<playerTimer>().setCookingTimer(10.0f);
		SoundsController.Instance.StartLoop("MicrowaveCook");
		SoundsController.Instance.Play ("Spoon");
		scored = false;
	}

	public void SetInvincible(bool invin){
		if (invin){
			playerState = STATE.INVINCIBLE;
		} else {
			playerState = STATE.OPEN;
		}
	}

	void CollectEnemy(GameObject enemy){
		collectedEnemyType = enemy.GetComponent<EnemyController>().type;
		playerState = STATE.COOKING;
		GameObject.Find("DoorHinge").GetComponent<DoorController>().Eat();
		SoundsController.Instance.Play("MicrowaveDoorClose");
		switch(collectedEnemyType){
		case 0:
			GetComponent<playerTimer>().setCookingTimer(6.0f);
			SoundsController.Instance.StartLoop("MicrowaveCook");
			scored = false;
			break;
		case 1:
			GetComponent<playerTimer>().setCookingTimer(3.0f);
			SoundsController.Instance.StartLoop("MicrowaveCook");
			scored = false;
			break;
		case 2:
			//GetComponent<PlayerHealth>().respawn();
			//GetComponent<PlayerHealth>().lives = 0;
			break;
		}
	}
}
