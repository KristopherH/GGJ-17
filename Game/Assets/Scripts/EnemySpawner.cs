using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public bool spawningActive;

	[SerializeField] GameObject enemyPrefab;
	[SerializeField] ArrayList enemies;
	[SerializeField] int spawnTimer;

	public int timeBetweenSpawns = 30;
	public Vector3 enemyDirectionAtSpawn = new Vector3(-1.0f, 0.0f, 0.0f);
	public float forceOfSpawn = 1.0f;

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
			//SpawnEnemy
			GameObject newEnemy = Instantiate(enemyPrefab);
			newEnemy.GetComponent<EnemyController>().moveDirection = enemyDirectionAtSpawn;
			newEnemy.GetComponent<EnemyController>().type = (int)Random.Range(0, 3/*add number of enemy types*/);
			newEnemy.transform.position = this.transform.position;
			Vector3 enemyDirection = enemyDirectionAtSpawn;
			enemyDirection.Normalize();
			enemyDirection*=forceOfSpawn;
			newEnemy.GetComponent<Rigidbody>().AddForce(enemyDirection);
			enemies.Add(newEnemy);
		}
	}
}
