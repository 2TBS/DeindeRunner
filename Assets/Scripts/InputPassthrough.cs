//InputPassthrough
//Author: Ben C.
//Editors: Omar H.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassthrough : MonoBehaviour {
	[Range (1, 2)] public int playerNo;
	private Player player;
	private bool jumpRequest;
	private bool shootRequest;
	private float horizontal;

	[SerializeField]
	private InputManager input;

	void Awake () {
		player = GetComponent<Player> ();
	}

	void Update () {
		if (playerNo == 2)
			return;
		// Update Input
		if (!jumpRequest) {
			jumpRequest = Input.GetButtonDown ("Jump");
		}
		shootRequest = Input.GetButtonDown ("Shoot");
		horizontal = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate () {
		// Move player
		player.Move (horizontal, jumpRequest);
		if (shootRequest)
			player.Shoot ();
		jumpRequest = false;
	}

}