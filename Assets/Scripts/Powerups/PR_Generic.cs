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

	[SerializeField] private float speedIncrease = 2;

	// Use this for initialization
	void Start () {
		//collider = gameObject.GetComponent<Collider2D>();
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player")
            ApplyEffects(coll.gameObject);
    }

	public void ApplyEffects(GameObject player){
		switch (prtype)
		{	
			//Add the powerup code in each case statement
			case Powerup.Speed:{
				Debug.Log("OG Speed: " + player.GetComponent<PlayerMovement>().speed);
				player.GetComponent<PlayerMovement>().speed += speedIncrease; //Sets the players speed to a certain int
				Debug.Log("Speed Increase: " + speedIncrease);
				Debug.Log("New Speed: " + player.GetComponent<PlayerMovement>().speed);
				Destroy(gameObject);
				break;
			}
			case Powerup.Destroy:{
				Debug.Log("OG Destruction: ");
				Destroy(gameObject);
				Debug.Log("Destruction Increase: ");
				Debug.Log("New Destruction: ");
				break;
			}
			default:{
				break;
			}
		} 

	}

}
