using UnityEngine;
using System.Collections;

public class SoundsController : MonoBehaviour {

	public AudioSource[] sounds;

	static SoundsController _instance;
	public static SoundsController Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<SoundsController> ();
			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
		sounds = gameObject.GetComponentsInChildren<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Play(string name){
		foreach (AudioSource sound in sounds){
			if (sound.gameObject.name == name){
				sound.Play();
			}
		}
	}
}