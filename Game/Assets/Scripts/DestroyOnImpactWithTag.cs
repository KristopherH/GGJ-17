using UnityEngine;
using System.Collections;

public class DestroyOnImpactWithTag : MonoBehaviour {

	[SerializeField]
	private string[] tags;

	void OnTriggerEnter(Collider other)
	{
		foreach (string tag in tags) {
			if (other.tag == tag)
				GameObject.DestroyImmediate (other);
				//Call death effects???
		} 
	}
}
