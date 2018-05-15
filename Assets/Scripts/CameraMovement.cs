//Author: Adarsh I.
//Last Edited: Omar H. 4/19/18
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private bool isMoving = false;

	public InputManager inputManager;

	float CameraSpeed = 1f;
	float CameraAcceleration = .01f;
	float Camera2ndDerivative = 0.99f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		print("hello");
		// Start Coroutine is used for some methods that use time, WaitForSeconds() in this example
		StartCoroutine(PlayStartUp());
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
			Debug.Log (CameraSpeed / Time.deltaTime);

		}
	}

	//Stops animator after x seconds to allow game logic to take control
	IEnumerator PlayStartUp () {
		yield return new WaitForSeconds(5);
		print("hello");
		anim.enabled = false;
	}
}