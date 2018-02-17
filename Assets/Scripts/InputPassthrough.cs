using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {

	private PlayerMovement player;

	private bool jumpRequest;
	private bool shootRequest;
	private float h;

	[SerializeField]
    private InputManager input;

	void Awake() {
		player = GetComponent<PlayerMovement>();
	}

	void Update() {
		// Update Input
		if(!jumpRequest) {
			jumpRequest = Input.GetButtonDown("Jump");
		}
		shootRequest = Input.GetButtonDown("Shoot");
		h = Input.GetAxis("Horizontal");
	}

	void FixedUpdate() {
		// Move player
		player.Move(h, jumpRequest);
		if(shootRequest)
			player.Shoot();
		jumpRequest = false;
	}

}
