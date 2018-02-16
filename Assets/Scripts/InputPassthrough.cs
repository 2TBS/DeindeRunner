using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {

	private PlayerMovement player;

	private bool jumpRequest;

	void Awake() {
		player = GetComponent<PlayerMovement>();
	}

	void Update() {
		if(!jumpRequest) {
			jumpRequest = Input.GetButtonDown("Jump");
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
		player.Move(h, jumpRequest);
		jumpRequest = false;
	}

}
