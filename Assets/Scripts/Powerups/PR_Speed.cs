using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Speed Powerup. Created by Akash, moved to new file by Ben
public class PR_Speed : PR_Generic {

    // Amount to change the player speed by. Default player speed is 5
    [SerializeField] private float speedIncrease = 2;
    // Duration in seconds for the effects to take place.

    protected override void ApplyEffects (Player player) {
        print(player.name + " Picked up Speed Powerup");
        player.ChangeSpeed(speedIncrease);
    }

    protected override void RemoveEffects(Player player) {
        print(player.name + " Speed Powerup ran out!");
        player.ChangeSpeed(-speedIncrease);
    }
}