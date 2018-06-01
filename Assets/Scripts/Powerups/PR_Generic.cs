using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic PowerUp Class based of an Enumerator and Switch system
/// Author: Vikram Peddinti February 2018, Ben Cuan May 2018
/// </summary>
public abstract class PR_Generic : MonoBehaviour {

	// Time, in seconds, for the powerup to last for
	[SerializeField]
	private int duration = 0;

	// Time, in seconds after a player picks this item up, for the powerup to reappear
	private int respawnTime = 30;

	// Player that collected this powerup
	private Player pl;

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			pl = coll.gameObject.GetComponent<Player> ();
			if(CanPickUp(pl)) {
				ApplyEffects (pl);
				StartCoroutine (WaitToRemove());
				StartCoroutine (Respawn());
			}
		}
	}

	/// <summary>Override this with the desired functionality of the powerup.</summary>
	protected abstract void ApplyEffects (Player player);
	/// <summary>Override this with the desired functionality to remove powerup effects. Player should return to normal state afterwards. Does not have to be implemented.</summary>
	protected virtual void RemoveEffects (Player player) {}
	/// <summary>Conditions that must be satisfied before the player may pick up this powerup. Will always return true unless overridden.</summary>
	protected virtual bool CanPickUp (Player player) {return true;}

	private IEnumerator WaitToRemove() {
		yield return new WaitForSeconds(duration);
		RemoveEffects(pl);
	}

	// Temporarily moves powerup out of view so players cannot pick up before cooldown is up
	private IEnumerator Respawn() {
		transform.Translate(Vector2.up * 100);
		yield return new WaitForSeconds(respawnTime);
		transform.Translate(Vector2.down * 100);
	}

}