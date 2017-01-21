﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public GameObject respawnPoint;
	public int InvincibilityAfterRespawn;
	public int invincibility;
	public int lives;

	// Use this for initialization
	void Start () {
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (invincibility > 0){
			invincibility--;
		}
		if (lives <= 0){
			SceneManager.LoadSceneAsync("Game_Over");
		}
	}

	public void respawn(){
		if(invincibility <= 0){
			lives = lives-1;
		}
		transform.position = respawnPoint.transform.position;
		invincibility = InvincibilityAfterRespawn;
	}
}
