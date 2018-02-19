using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {

	private PlayerMovement playerMovement;
	private PlayerDestruction playerDestruction;
	private bool jumpRequest;
	private bool shootRequest;
	private float h;

	[SerializeField]
    private InputManager input;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement>();
		playerDestruction = GetComponent<PlayerDestruction>();
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
		playerMovement.Move(h, jumpRequest);
		if(shootRequest)
			playerDestruction.Shoot();
		jumpRequest = false;
	}

}
