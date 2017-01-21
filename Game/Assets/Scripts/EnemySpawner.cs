using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public bool spawningActive;

	[SerializeField] GameObject enemyPrefab;
	[SerializeField] ArrayList enemies;
	[SerializeField] int spawnTimer;

	public int timeBetweenSpawns;
	public Vector3 enemyDirectionAtSpawn;
	public Vector3 enemyDirection;
	public float forceOfSpawn;

	// Use this for initialization
	void Start () {
		spawnTimer = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawningActive){
			spawnTimer--;
		}
		if (spawnTimer <= 0){
			spawnTimer = timeBetweenSpawns;
			Spawn();
		}
	}
	public void Spawn(){
		//SpawnEnemy
		GameObject newEnemy = Instantiate(enemyPrefab);
		newEnemy.GetComponent<EnemyController>().moveDirection = enemyDirection;
		newEnemy.GetComponent<EnemyController>().type = (int)Random.Range(0, 3/*add number of enemy types*/);
		newEnemy.transform.position = this.transform.position;
		enemyDirectionAtSpawn.Normalize();
		enemyDirectionAtSpawn*=forceOfSpawn;
		newEnemy.GetComponent<Rigidbody>().AddForce(enemyDirectionAtSpawn);
		enemies.Add(newEnemy);
	}
}
