using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///Runs the heads-up display including player health, powerup status, and a pause menu.
public class HUD : MonoBehaviour {

	public Text p1Health, p2Health;
	private Player p1, p2;
	public Canvas pauseMenu;

	//Health and ammo
	public Sprite fullBulletPellet, emptyBulletPellet, fullHealthPellet, emptyHealthPellet;
	public PL_Shooting shootController;
	private GameObject[] bulletPellets, healthPellets;

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Player").GetComponent<Player> ();
		pauseMenu.enabled = false;

		bulletPellets = new GameObject[5];
		healthPellets = new GameObject[5];

		for (int i = 0; i < 5; i++) {
			bulletPellets[i] = GameObject.Find ("BulletPellet (" + i + ")");
			healthPellets[i] = GameObject.Find ("FullHealthPellet (" + i + ")");
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

		//Health and Ammo
		for (int i = 0; i < 5; i++) {
			if (shootController.ammo <= i)
				bulletPellets[i].GetComponent<Image> ().sprite = fullBulletPellet;
			if (p1.health > 0)
				healthPellets[i].GetComponent<Image> ().sprite = fullHealthPellet;
		}
	}

	//Button Actions

	public void TogglePauseMenu () {
		Time.timeScale = (pauseMenu.enabled) ? 1 : 0;
		pauseMenu.enabled = !pauseMenu.enabled;
	}

	public void ReturnToMenu () {
		SceneManager.LoadScene ("MainMenu");
	}
}