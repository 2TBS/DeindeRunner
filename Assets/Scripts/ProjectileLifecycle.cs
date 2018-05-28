/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Attach to projectiles to facilitate collisions.</summary>
public class ProjectileLifecycle : MonoBehaviour {

	// Update is called once per frame

	[SerializeField] private int damage = 1;
	[SerializeField] private int snipedamage = 2;
	[SerializeField] private int weapondamage = 3;


    // method for checking for whether the projectiles have collided or not
	void OnCollisionEnter2D (Collision2D col) {
		//this if statement is for regular projectiles/bullets 
		if (col.gameObject.tag == "Damageable") {
			col.gameObject.GetComponent<Destructable> ().Damage (damage);
			Destroy (gameObject);
		}
		// this else if statement is for the "sniper" powerup
        else if(col.gameObejct.tag == "Damageable") {
            col.gameObejct.GetComponent<Destructable> ().Damage (snipedamage);
          	Destroy (gameObject);
		}
        // this else if statement is for the "weapons" implemented in the game 
	    else if(col.gameObejct.tag == "Damageable") {
            col.gameObejct.GetComponent<Destructable> ().Damage (weapondamage);
          	Destroy (gameObject);
		}
		  
	}
    





}*/