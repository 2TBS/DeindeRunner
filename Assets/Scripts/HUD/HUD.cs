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

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Player").GetComponent<Player> ();
		pauseMenu.enabled = false;
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