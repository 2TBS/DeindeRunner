//InputPassthrough
//Author: Ben C.
//Editors: Omar H.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Manages all keyboard and controller input towards the players. Attach to the Player object.</summary>
/// Author: Ben Cuan
/// Last edit: 19 April 2018
public class InputPassthrough : MonoBehaviour {
	///Player number, there are only two players supported.
	[Range (1, 2)] public int playerNo;
	///Player object attached to this same GameObject
	private Player player;
	///Is the jump key pressed?
	private bool jumpRequest;
	///Is the shoot key pressed?
	private bool shootRequest;
	///Input for the Horizontal axis
	private float horizontal;

	[SerializeField]
	private InputManager input;

    // receiver of player input
 	void Awake () {
		input = InputManager.GetInputManager();
		player = GetComponent<Player> ();
	}

	void Update () {

		// Update Input
		if (!jumpRequest)
			jumpRequest = input.GetKeyDown ("Player" + playerNo + "Jump");
		shootRequest = input.GetKeyDown ("Player" + playerNo + "Shoot");
		horizontal = input.GetAxis ("Player" + playerNo + "Horizontal");
	}

	void FixedUpdate () {
		// Move player
		player.Move (horizontal, jumpRequest);
		if (shootRequest)
			player.Shoot ();
		jumpRequest = false;
	}

}