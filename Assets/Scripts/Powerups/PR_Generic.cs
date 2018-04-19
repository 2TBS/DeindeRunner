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

	[SerializeField] private float destructionIncrease = 2;

  [SerializeField] private float healthIncrease = 1;

	[SerializeField] private float duration = 3;
HUDHealth hud = new HUDHealth();
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
				Debug.Log("OG Speed: " + player.GetComponent<Player>().moveSpeed);
				player.GetComponent<Player>().PowerUpSpeed(speedIncrease, duration);
				//player.GetComponent<Player>().speed += speedIncrease; //Sets the players speed to a certain int
				Debug.Log("Speed Increase: " + speedIncrease);
				Debug.Log("New Speed: " + player.GetComponent<Player>().moveSpeed);
				Destroy(gameObject);
				break;
			}
			case Powerup.Destroy:{
				Debug.Log("OG Destruction: ");
				player.GetComponent<Player>().PowerUpDestruction(destructionIncrease, duration);
				Debug.Log("Destruction Increase: ");
				Debug.Log("New Destruction: ");
				Destroy(gameObject);
				Debug.Log("Damage Powerup Used");
				break;
			}
			default:{
				break;
			}
    }

	}}
