using UnityEngine;
using System.Collections;

public class SpoonMode : MonoBehaviour {

	[SerializeField] float modeLength;
	[SerializeField] GameObject endParticles;
	float timer;

	PlayerAttack pa;

	void OnEnable()
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
		Instantiate (endParticles, transform.position, transform.rotation);
		//Death effect
		//GetComponentInParent<PlayerHealth> ().Kill();
	}
}
