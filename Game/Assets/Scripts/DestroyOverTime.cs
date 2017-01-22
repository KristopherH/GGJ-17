using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	[SerializeField] float lifetime;
	float timer;

	// Use this for initialization
	void Start () 
	{
		timer = lifetime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
			GameObject.Destroy (this.gameObject);
	}
}
