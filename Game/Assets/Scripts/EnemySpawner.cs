using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public bool spawningActive;

	[SerializeField] GameObject enemyPrefab1;
	[SerializeField] GameObject enemyPrefab2;
	[SerializeField] GameObject enemyPrefab3;
	[SerializeField] ArrayList enemies;
	[SerializeField] int spawnTimer;

	public int timeBetweenSpawns;
	public Vector3 enemyDirectionAtSpawn;
	public Vector3 enemyDirection;
	public float forceOfSpawn;

	// Use this for initialization
	void Start () {
		spawnTimer = 0;
		enemies = new ArrayList();
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
		int type = (int)Random.Range(0, 2/*add number of enemy types*/);
		GameObject newEnemy;
		switch(type){
		case 0:
			newEnemy = Instantiate(enemyPrefab1);
			break;
		case 1:
			newEnemy = Instantiate(enemyPrefab2);
			break;
		case 2:
		 	newEnemy = Instantiate(enemyPrefab3);
			break;
		default:
			newEnemy = Instantiate(enemyPrefab3);
			break;
		}

		int dice = (int) Random.Range(0, 100);
		if ( dice < 50){
			newEnemy.GetComponent<EnemyController>().moveDirection = enemyDirection;
		} else {
			newEnemy.GetComponent<EnemyController>().moveDirection = -enemyDirection;
		}
		newEnemy.GetComponent<EnemyController>().type = type;
		newEnemy.transform.position = this.transform.position;
		enemyDirectionAtSpawn.Normalize();
		enemyDirectionAtSpawn*=forceOfSpawn;
		newEnemy.GetComponent<Rigidbody>().AddForce(enemyDirectionAtSpawn);
		enemies.Add(newEnemy);
	}
}