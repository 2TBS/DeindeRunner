using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Speed Powerup. Created by Akash, moved to new file by Ben
public class PR_Speed : PR_Generic {

    [SerializeField] private float destructionIncrease = 2;
    [SerializeField] private float duration = 3;

    public override void ApplyEffects (Player player) {
        Debug.Log ("OG Destruction: ");
        player.PowerUpDestruction (destructionIncrease, duration);
        Debug.Log ("Destruction Increase: ");
        Debug.Log ("New Destruction: ");
        Destroy (gameObject);
        Debug.Log ("Damage Powerup Used");
    }
}