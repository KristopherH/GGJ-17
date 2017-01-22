using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public Vector3 direction;
	public int life;

	GameObject enemyDeath;

	// Use this for initialization
	void Start () {
		enemyDeath = FXController.Instance.enemyDeath;
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction*Time.deltaTime;
		transform.Rotate(new Vector3(0, 2, 0));
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy"){
			Instantiate (enemyDeath, other.transform.position, other.transform.rotation);
			SoundsController.Instance.Play ("EnemyHit");
			Destroy(other.gameObject);
			Score.Instance.increaseScore(2);
			life--;
			if (life <= 0){
				Destroy(this.gameObject);
			}
		}
	}
}
