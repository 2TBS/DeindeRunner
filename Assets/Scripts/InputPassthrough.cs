using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {

	private PlayerMovement player;

	private bool jumpRequest;

	[SerializeField]
    private InputManager input;

	void Awake() {
		player = GetComponent<PlayerMovement>();
	}

	void Update() {
		if(!jumpRequest) {
			jumpRequest = input.GetKeyDown("Jump");
		}
	}

	void FixedUpdate() {
		float h = input.GetAxis("Horizontal");
		player.Move(h, jumpRequest);
		jumpRequest = false;
	}

}
