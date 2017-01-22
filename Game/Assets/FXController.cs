using UnityEngine;
using System.Collections;

public class FXController : MonoBehaviour {

	static FXController _instance;
	public static FXController Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<FXController> ();
			return _instance;
		}
	}

	public GameObject enemyDeath;
	public GameObject playerDeath;
}
