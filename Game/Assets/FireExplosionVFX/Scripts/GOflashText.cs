using UnityEngine;
using System.Collections;

public class GOflashText : MonoBehaviour {

    public GameObject flashingText;
    private float timer;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Text", 1, timer);
	}
	
	// Update is called once per frame
	void Update () {

        if (flashingText.activeSelf)
            flashingText.SetActive(false);
        else
            flashingText.SetActive(true);
    }
	
}
