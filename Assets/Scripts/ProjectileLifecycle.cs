using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Attach to projectiles to facilitate collisions.</summary>
/// Contributors: Ben Cuan, Unknown (maybe Akash)?
public class ProjectileLifecycle : MonoBehaviour {

	// Update is called once per frame

	[SerializeField] private int damage = 1;
	[SerializeField] private int snipedamage = 2;
	[SerializeField] private int weapondamage = 3;

    // method for checking for whether the projectiles have collided or not
	void OnCollisionEnter2D (Collision2D col) {
		//this if statement is for players
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player> ().health -= damage;
			Destroy (gameObject);
		}
		// Terrain
        else if(col.gameObject.tag == "Ground") {
          	Destroy (gameObject);
		}
        // this else if statement is for the "weapons" implemented in the game 
	    else if(col.gameObject.tag == "Damageable") {
            col.gameObject.GetComponent<Destructable> ().Damage (weapondamage);
          	Destroy (gameObject);
		}	
	}
}