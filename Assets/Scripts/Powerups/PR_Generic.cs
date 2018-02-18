using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic PowerUp Class based of an Enumerator and Switch system
/// Author: Vikram Peddinti February 2018
/// </summary>
public enum Powerup
{
	Speed = 0,
	Destroy = 1
}


public class PR_Generic : MonoBehaviour {

	public Powerup prtype;
	//public Collider2D collider;

	// Use this for initialization
	void Start () {
		//collider = gameObject.GetComponent<Collider2D>();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
            ApplyEffects();
    }

	public void ApplyEffects(){
		switch (prtype)
		{	
			//Add the powerup code in each case statement
			case Powerup.Speed:{
				Debug.Log("How Speedy?");
				Destroy(gameObject);
				break;
			}
			case Powerup.Destroy:{
				Debug.Log("How Destructiony?");
				Destroy(gameObject);
				break;
			}
			default:{
				break;
			}
		} 

	}

}
