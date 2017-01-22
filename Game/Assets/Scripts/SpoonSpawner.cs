using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	int startCookDelay;

	[SerializeField]
	int maxCookDelay;

	int cookCountDown;

	ArrayList spoons = new ArrayList();

	// Use this for initialization
	void Start () {
		cookCountDown = startCookDelay;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
			RegisterCook();
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
		Debug.Log ("SPAWN");
		if (spoons.Count > 0)
			return;
		startCookDelay = startCookDelay == maxCookDelay ? maxCookDelay : startCookDelay + 1;
		cookCountDown = startCookDelay;
		GameObject spoon = Instantiate (spoonPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;  
		spoons.Add (spoon);
	}

	public void DestroyAllSpoons()
	{
		foreach (GameObject spoon in spoons) 
		{
			GameObject.Destroy (spoon);
		}
	}
}
