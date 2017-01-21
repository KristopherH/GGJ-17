using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	Color[] colours;

	[SerializeField]
	float phaseTime;

	[SerializeField]
	float phaseSpeed;

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
		phaseTimer = 0.0f;
		lastColourIndex = 0;
		targetColor = colours [0];
	}

	// Update is called once per frame
	void Update () 
	{
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
