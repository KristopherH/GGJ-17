using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static PlayerController _instance;
	public static PlayerController Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<PlayerController> ();
			return _instance;
		}
	}


	//PUT STUFF IN HERE AS THE PARENT SCRIPT OF OTHERS
}
