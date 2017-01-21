using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	private EnemySpawner[] spawners;

	private int startup;
	// Use this for initialization
	void Start () {
		spawners = GetComponentsInChildren<EnemySpawner>();
		startup = 50;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (Enemies.Length < 50){
			if (startup <= 0){
				int dice = Random.Range(0, 100);
				if (dice < 1){
					int selected = Random.Range(0, spawners.Length);
					spawners[selected].Spawn();
				}
			} else {
				startup--;
			}
		}
	}
}
