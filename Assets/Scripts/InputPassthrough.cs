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
<<<<<<< HEAD
		shootRequest = Input.GetButtonDown("Shoot");
		horizontal = Input.GetAxis("Horizontal");
=======
		shootRequest = Input.GetButtonDown ("Shoot");
		h = Input.GetAxis ("Horizontal");
>>>>>>> 9f956f398caa8c0a328ece52f8092e064423b40a
	}

	void FixedUpdate () {
		// Move player
<<<<<<< HEAD
		player.Move(horizontal, jumpRequest);
		if(shootRequest)
			player.Shoot();
=======
		player.Move (h, jumpRequest);
		if (shootRequest)
			player.Shoot ();
>>>>>>> 9f956f398caa8c0a328ece52f8092e064423b40a
		jumpRequest = false;
	}

}