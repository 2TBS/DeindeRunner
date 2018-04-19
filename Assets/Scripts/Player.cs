// Player.cs
// Author: Adarsh I.
// Editors: Omar H.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float maxSpeed = 7.0f;
	[Range(1, 10)] public float speed = 5.0f;
	[Range(1, 10)] public float jumpForce;
	private Rigidbody2D rb;
	private Vector2 playerSize;
	private Vector2 boxSize;
	private Vector2 boxCenter;
	private float groundCheckMargin = 0.05f;
	public LayerMask groundLayer;
	public bool speedPowerUpOn;
	private bool grounded;

	[SerializeField] private Transform projectile;
	[Range(0, 15)] public float firePower = 15.0f;
	private float time;
	public bool destructionPowerUpOn;

	//Player health
	private const int MAX_HEALTH = 3;
	public int health = MAX_HEALTH;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		playerSize = GetComponent<BoxCollider2D>().size;
		boxSize = new Vector2(playerSize.x, groundCheckMargin);
		destructionPowerUpOn = false;
		time = 0;
	}

//This whole method makes no sense, pls comment
	void FixedUpdate() {
		grounded = false;
		// Ground collision logic, note that the box is a small box with the width of the player and the height of groundlayer
			// Its like a small sliver right beneath the play box
		boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f; 
		grounded =  Physics2D.OverlapBox(boxCenter, boxSize, 0f, groundLayer) != null;

		if(!checkInView()) {
			resetPosition();
		}
		//Add timer for powerup
	}

	//Checks if the player is in view of the camera
	bool checkInView() {
		//If you see an error in your editor for the next line, ign it. It's a unity thing
		if (!GetComponent<Renderer>().IsVisibleFrom(Camera.main)) {
	   		Debug.Log("Not Visible");
		}
		return GetComponent<Renderer>().IsVisibleFrom(Camera.main);
	}

	void resetPosition() {
		Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
        this.transform.position = centerPos;
		rb.velocity = new Vector2(0.0f, 0.0f);
		Debug.Log("Position Reset, deducted health");
		health--;
		Debug.Log("New health: " + health);
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

    public void Move(float move, bool jump) {
		if(!WillHitWall(move)) {
			float t = rb.velocity.x / maxSpeed;
			
			float lerp = Mathf.Lerp(maxSpeed, 0f, Mathf.Abs(t));

			Vector2 movement = new Vector2(lerp * speed, 0f);
			movement.x *= move;

			rb.AddForce(movement * rb.mass, ForceMode2D.Force);
		}

		if(jump && grounded) {
			Jump();
		}

	}
	
    

	private void Jump() {
		GetComponent<Rigidbody2D>().gravityScale = 1;
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		grounded = false;
	}

	private bool WillHitWall(float move) {
		RaycastHit2D hit;
		bool hitWall = false;
		if (move > 0f) {
			if(hit = Physics2D.CircleCast(transform.position, .5f, transform.right, .6f)) {
				if(hit.collider.tag == "Environment") {
					hitWall = true;
				}
			}
		}
		else if (move < 0f) {
			if(hit = Physics2D.CircleCast(transform.position, .5f, -transform.right, .6f)) {
				if(hit.collider.tag == "Environment") {
					hitWall = true;
				}
			}
		}

		return hitWall;
	}

	public void Shoot() {
        Transform clone = Instantiate(projectile, new Vector2(transform.position.x + (playerSize.x * 2f/3f), transform.position.y), 
			projectile.rotation);
		clone.GetComponent<Rigidbody2D>().velocity = Vector2.right * firePower;
		Destroy(clone.gameObject, 10.0f);
    }


	public void PowerUpSpeed(float speedIncrease, float duration) {
		speed += speedIncrease;
	}

	public void PowerUpDestruction(float destructionIncrease, float duration) {
		//destruction += destructionIncrease;
	}

}
