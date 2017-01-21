using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	GameObject[] parts;

	Vector3[] positions;


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

	void Awake()
	{
		positions = new Vector3[parts.Length];

		for (int i = 0; i < parts.Length; i++) 
		{
			positions [i] = parts [i].transform.localPosition;
		}
	}

	void Update()
	{
		for (int i = 0; i < parts.Length; i++) {
			parts [i].transform.localPosition = positions [i];
		
		}
	}


	//PUT STUFF IN HERE AS THE PARENT SCRIPT OF OTHERS
}
