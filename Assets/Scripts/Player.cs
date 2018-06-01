// Player.cs
// Author: Adarsh I.
// Editors: Omar H. and Ben C.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float maxSpeed = 7.0f;
	[Range (1, 10)] public float speed = 5.0f;
	[Range (1, 10)] public float jumpForce;
	[Range (1, 2)] public int playerNo;
	private Rigidbody2D rb;
	private Vector2 playerSize;
	private Vector2 boxSize;
	private Vector2 boxCenter;
	private float groundCheckMargin = 0.05f;
	public LayerMask groundLayer;
	public bool speedPowerUpOn;
	private bool grounded;
	public Collider2D levelBounds; // Assign in level, this is an empty sprite with a custom Box Collider. 

	[SerializeField] private Transform projectile;
	[Range (0, 15)] public float firePower = 15.0f;
	private float time;
	public bool destructionPowerUpOn;

	//Player health
	private const int MAX_HEALTH = 5;
	public int health = MAX_HEALTH;

	//method for 
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		playerSize = GetComponent<BoxCollider2D> ().size;
		boxSize = new Vector2 (playerSize.x, groundCheckMargin);
		destructionPowerUpOn = false;
		time = 0;
		rb.freezeRotation = true;
	}

	//This whole method makes no sense, pls comment
	void FixedUpdate () {
		grounded = false;
		// Ground collision logic, note that the box is a small box with the width of the player and the height of groundlayer
		// Its like a small sliver right beneath the play box
		boxCenter = (Vector2) transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f; // transforms  player in certain direction
		grounded = Physics2D.OverlapBox (boxCenter, boxSize, 0f, groundLayer) != null; // ground 

		if (!checkInView ()) {
			resetPosition ();
		}
		//Add timer for powerup
	}

	//Checks if the player is in the bounds of the map. Returns true if out of bounds OR behind the camera.
	bool checkInView () {
		// print (GetComponent<Collider2D> ().IsTouching (levelBounds));
		return GetComponent<Collider2D> ().IsTouching (levelBounds) && transform.position.x >= Camera.main.transform.position.x - 10f;
	}

	// Sets player position to center of screen if player is outside of level bounds or has died.
	// this method needs changing!!!
	// reseting to the center isn't necessarily a good thing!!! 
	void resetPosition () {
		// Consult the documentation at https://docs.unity3d.com/ScriptReference/Camera.ViewportToWorldPoint.html if you're confused as to what the below numbers mean.
		Vector3 resetPos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.9f, 10f));
		this.transform.position = resetPos;
		rb.velocity = new Vector2 (0.0f, 0.0f);
		print ("reset to " + resetPos);
		health--;
		Debug.Log ("Player " + playerNo + " New health: " + health);
	}

	/*void Update() {
		if(destructionPowerUpOn) {
			time += Time.deltaTime;
			if(time > seconds) {
				time = 0;
				//Set Destruction back to OG Destruction
			}
		}
		else {time = 0;}
	}*/
	// method for hitting the wall(PLEASE CHANGE THIS)
	public void Move (float move, bool jump) {
		if (!WillHitWall (move)) {
			float t = rb.velocity.x / maxSpeed;

			float lerp = Mathf.Lerp (maxSpeed, 0f, Mathf.Abs (t));

			Vector2 movement = new Vector2 (lerp * speed, 0f);
			movement.x *= move;

			rb.AddForce (movement * rb.mass, ForceMode2D.Force);
		}

		if (jump && grounded) {
			Jump ();
		}

	}

	private void Jump () {
		GetComponent<Rigidbody2D> ().gravityScale = 1;
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		grounded = false;
	}

	private bool WillHitWall (float move) {
		RaycastHit2D hit;
		bool hitWall = false;
		if (move > 0f) {
			if (hit = Physics2D.CircleCast (transform.position, .5f, transform.right, .6f)) {
				if (hit.collider.tag == "Environment") {
					hitWall = true;
				}
			}
		} else if (move < 0f) {
			if (hit = Physics2D.CircleCast (transform.position, .5f, -transform.right, .6f)) {
				if (hit.collider.tag == "Environment") {
					hitWall = true;
				}
			}
		}

		return hitWall;
	}

	public void Shoot () {
		Transform clone = Instantiate (projectile, new Vector2 (transform.position.x + (playerSize.x * 2f / 3f), transform.position.y),
			projectile.rotation);
		clone.GetComponent<Rigidbody2D> ().velocity = Vector2.right * firePower;
		Destroy (clone.gameObject, 10.0f);
	}

	/// Increments or decrements speed by given amount.
	/// For use with powerups.
	public void ChangeSpeed(float speedChange) {
		speed += speedChange;
	}

	/// Increments or decrements health by given amount.
	/// For use with powerups.
	public void ChangeHealth(int healthChange) {
		health += healthChange;
	}

}