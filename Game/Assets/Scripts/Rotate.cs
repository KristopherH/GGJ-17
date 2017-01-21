using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    // Use this for initialization

    // Update is called once per frame
    public float speed = 10f;
	void Update () {

        transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
