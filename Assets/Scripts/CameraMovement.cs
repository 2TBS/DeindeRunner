using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private bool isMoving = false;

	public InputManager inputManager;

    float CameraSpeed = 0.02f;
	float CameraAcceleration = .01f;
	float Camera2ndDerivative = 0.99f;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
			isMoving = !isMoving;
		if (isMoving) {
			transform.Translate (Vector2.right * CameraSpeed);

		}
	}
}
