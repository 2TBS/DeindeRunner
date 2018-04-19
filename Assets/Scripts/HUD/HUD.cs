//Author: Omar Hossain, Ben Cuan
//Last Edited: Omar Hossain 4/19/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>Runs the heads-up display including player health, powerup status, and a pause menu. </summary>
public class HUD : MonoBehaviour {

	// public Text p1Health, p2Health;
	private Player p1, p2;
	public Canvas pauseMenu;

	// Health and ammo
	public Sprite fullBulletPellet, emptyBulletPellet, fullHealthPellet, emptyHealthPellet;
	public PL_Shooting shootController;
	private GameObject[] bulletPellets, healthPellets;

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Player 1").GetComponent<Player> ();
		pauseMenu.enabled = false;

		bulletPellets = new GameObject[5];
		healthPellets = new GameObject[5];

		// Finds bulletPellets by finding the names Bullet/FullHealthPellets (1/2/3/4/5) and
			// storing them in an array
		for (int i = 0; i < 5; i++) {
			bulletPellets[i] = GameObject.Find ("BulletPellet (" + (i+1) + ")");
			healthPellets[i] = GameObject.Find ("FullHealthPellet (" + (i+1) + ")");
			// Checks to see if for loop is correctly finding bullets
			//print("Finding FullHealthPellet " + (i+1) + ": "+ healthPellets[i]);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TogglePauseMenu ();
		}

		if (p1.health == 0) {
			Debug.Log ("p1 health zero");
			SceneManager.LoadScene ("Game Over");
		}

		// Health and Ammo
		for (int i = 0; i < 5; i++) {
			//Implement when implementing limited shooting
			/*if (shootController.ammo <= i)
				bulletPellets[i].GetComponent<Image> ().sprite = fullBulletPellet;*/
			if (p1.health > i)
				healthPellets[i].GetComponent<Image> ().sprite = fullHealthPellet;
		}

		for (int i = 5; i > 0; i--) {
			//Implement when implementing limited shooting
			/*if (shootController.ammo <= i)
				bulletPellets[i].GetComponent<Image> ().sprite = fullBulletPellet;*/
			if (p1.health == i) {
				// Makes all depleted bullets have empty sprite
				for (int j = (5-1); j > (i-1); j--)
					healthPellets[j].GetComponent<Image> ().sprite = emptyHealthPellet;
				// Makes all existing bullets have full sprite	
				for (int j = 0; j <= (i-1); j++)
					healthPellets[j].GetComponent<Image> ().sprite = fullHealthPellet;
			}
		}

	}

	// Button Actions

	public void TogglePauseMenu () {
		Time.timeScale = (pauseMenu.enabled) ? 1 : 0;
		pauseMenu.enabled = !pauseMenu.enabled;
	}

	public void ReturnToMenu () {
		SceneManager.LoadScene ("MainMenu");
	}
}