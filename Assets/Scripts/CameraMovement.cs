//Author: Adarsh I.
//Last Edited: Omar H. 4/19/18, Ben C. 6/9/18
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {
	private bool isMoving = false;

	public InputManager inputManager;

	float CameraSpeed = 1f;
	float CameraAcceleration = .01f;
	float Camera2ndDerivative = 0.99f;
	public Animator anim;

	private Text fightText;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fightText = GameObject.Find("FightText").GetComponent<Text>();
		print ("hello");
		// Start Coroutine is used for some methods that use time, WaitForSeconds() in this example
		StartCoroutine (PlayStartUp ());
	}

	// Update is called once per frame
	void Update () {

		//removed input for T
		isMoving = !isMoving;
		if (isMoving) {
			transform.Translate (Vector2.right * (CameraSpeed * Time.deltaTime));
			// No acceleration for now
			// CameraSpeed = CameraSpeed * (1 + CameraAcceleration);
			// CameraAcceleration = CameraAcceleration * Camera2ndDerivative;
			// Debug.Log (CameraSpeed / Time.deltaTime);

		}

		if (fightText.isActiveAndEnabled)
			fightText.color = new Color(fightText.color.r, fightText.color.g, fightText.color.b, fightText.color.a - 0.02f);

	}

	//Stops animator after x seconds to allow game logic to take control
	IEnumerator PlayStartUp () {
		yield return new WaitForSeconds (5);
		print ("starting fight");
		fightText.enabled = true;
		anim.enabled = false;

		yield return new WaitForSeconds (2);
		fightText.enabled = false;
	}
}