using UnityEngine;
using System.Collections;

public class SpoonMode : MonoBehaviour {

	[SerializeField] float modeLength;
	float timer;

	PlayerAttack pa;

	// Use this for initialization
	void Start () 
	{
		pa = GetComponentInParent<PlayerAttack> ();
		timer = modeLength;
		Player_Controller pc = GetComponentInParent<Player_Controller> ();
		SpoonSpawner.Instance.DestroyAllSpoons ();
		pa.SetInvincible (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0.0f)
			TimeExpired();
	}

	void ReleaseSpoon()
	{
		pa.SetInvincible (false);
		this.gameObject.SetActive (false);
	}

	void TimeExpired()
	{
		this.gameObject.SetActive (false);
		//Death effect
		//GetComponentInParent<PlayerHealth> ().Kill();
	}
}
