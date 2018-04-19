using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic PowerUp Class based of an Enumerator and Switch system
/// Author: Vikram Peddinti February 2018, Ben Cuan April 2018
/// </summary>
public abstract class PR_Generic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//collider = gameObject.GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
			ApplyEffects (coll.gameObject.GetComponent<Player>());
	}

	/// <summary>Override this with the desired functionality of the powerup.</summary>
	public abstract void ApplyEffects (Player player);
}