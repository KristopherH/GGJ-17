using UnityEngine;
using System.Collections;

public class SpoonSpawner : MonoBehaviour {
	
	static SpoonSpawner _instance;
	public static SpoonSpawner Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<SpoonSpawner> ();
			return _instance;
		}
	}

	[SerializeField]
	GameObject spoonPrefab;
	[SerializeField]
	int cookDelay;

	int cookCountDown;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
			
	}

	public void RegisterCook()
	{
		Debug.Log ("COOK");
		cookCountDown--;
		if (cookCountDown <= 0)
			Spawn ();
	}

	void Spawn()
	{
		cookDelay++;
		cookCountDown = cookDelay;
		Instantiate (spoonPrefab, gameObject.transform.position, gameObject.transform.rotation);  
	}
}
