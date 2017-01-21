using UnityEngine;
using System.Collections;

public class PopCorn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)){
			Shoot();
		}
	}

	

	public void Shoot(){
		ParticleSystem[] pops = GetComponentsInChildren<ParticleSystem>();

		for (int i = 0; i < pops.Length; i++){
			pops[i].Play();
		}
	}

}