using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	Color[] colours;

	[SerializeField]
	float phaseTime;

	[SerializeField]
	float phaseSpeed;

	[SerializeField]
	float startWait;
	float startTimer;

	Color targetColor;
	float phaseTimer;
	Renderer rend;
	int lastColourIndex;

	void Awake()
	{
		rend = gameObject.GetComponent<Renderer> ();
	}

	void Start()
	{
		startTimer = startWait;
		phaseTimer = 0.0f;
		lastColourIndex = 0;
		targetColor = colours [0];
	}

	// Update is called once per frame
	void Update () 
	{
		if (startWait > 0.0f) {
			startWait -= Time.deltaTime;
			return;
		}
		if (phaseTimer <= 0.0f) 
		{
			phaseTimer = phaseTime;
			lastColourIndex = lastColourIndex + 1 >= colours.Length ? 0 : lastColourIndex + 1;
			targetColor = colours[lastColourIndex];
		}
		LerpColour ();
		phaseTimer -= Time.deltaTime;
	}

	void LerpColour()
	{
		rend.material.color = Color.Lerp (rend.material.color ,targetColor, Time.deltaTime * phaseSpeed);
	}
}
