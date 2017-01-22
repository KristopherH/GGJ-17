using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {

	[SerializeField]
	GameObject enemyDiePrefab;

//	// Use this for initialization
//	void Awake () {
//		if (enemyDiePrefab == null) {
//			Debug.Log ("no prefab for death of " + gameObject.ToString ());
//		}
//		Instantiate (enemyDiePrefab, gameObject.transform.parent.position, gameObject.transform.parent.rotation);
//	}
}
