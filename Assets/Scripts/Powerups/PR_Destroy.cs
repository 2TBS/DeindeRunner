using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Destroy Powerup. Created by Akash, moved to new file by Ben
public class PR_Destroy : PR_Generic {

    [SerializeField] private float speedIncrease = 2;
    [SerializeField] private float duration = 3;

    public override void ApplyEffects (Player player) {
        Debug.Log ("OG Speed: " + player.GetComponent<Player> ().speed);
        player.PowerUpSpeed (speedIncrease, duration);
        player.speed += speedIncrease; //Sets the players speed to a certain int
        Debug.Log ("Speed Increase: " + speedIncrease);
        Debug.Log ("New Speed: " + player.GetComponent<Player> ().speed);
        Destroy (gameObject);
    }
}