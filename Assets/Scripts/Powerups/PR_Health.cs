using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Speed Powerup. Created by Ben Cuan, 31 May 2018
public class PR_Health : PR_Generic {

	// Amount to change the player health by. Max health is 5
	[SerializeField] private int healthIncrease = 2;
	// Duration in seconds for the effects to take place.

	protected override void ApplyEffects (Player player) {
		print (player.name + " Picked up Health Powerup");
		player.ChangeHealth(healthIncrease);
	}

	// No effects to remove.
	protected override void RemoveEffects (Player player) {}
}