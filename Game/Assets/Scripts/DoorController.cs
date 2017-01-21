using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	Animator animator;
	bool open;

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		/*if(Input.GetButtonDown("Jump"))
		{
			if (open) {
				Eat ();
			} else {
				FinishCook ();
			}
		}*/
	}

	public void FinishCook()
	{
		animator.Play("Door_FinishedCook");
		open = true;
	}

	public void Eat()
	{
		animator.Play("Door_Eat");
		open = false;
	}
}
