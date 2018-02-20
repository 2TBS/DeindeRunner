using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {
	[Range(1, 2)] public int playerNo;
	private Player player;
	private bool jumpRequest;
	private bool shootRequest;
	private float h;

	[SerializeField]
    private InputManager input;

	void Awake() {
		player = GetComponent<Player>();
	}

	void Update() {
		if(playerNo == 2)
			return;
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
