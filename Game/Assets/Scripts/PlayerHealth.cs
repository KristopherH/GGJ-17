using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public GameObject respawnPoint;
	public int InvincibilityAfterRespawn;
	public int invincibility;
	public int lives;
	bool alive;

	// Use this for initialization
	void Start () {
		lives = 3;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (invincibility > 0){
			invincibility--;
		}
		if (lives <= 0 && alive){
			StartCoroutine("GameOver");
			alive = false;
		}
	}

	IEnumerator GameOver() {
		Instantiate(FXController.Instance.playerDeath,gameObject.transform.position,gameObject.transform.rotation);
		yield return new WaitForSeconds(2);
		SceneManager.LoadSceneAsync(3);
		SoundsController.Instance.Play("Boo");
		yield return null;
	}

	public void respawn(){
		if(invincibility <= 0){
			lives = lives-1;
		}
		transform.position = respawnPoint.transform.position;
		invincibility = InvincibilityAfterRespawn;
	}

	public void Kill(){
		lives = 0;
	}
}
