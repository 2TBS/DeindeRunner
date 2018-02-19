using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifecycle : MonoBehaviour {
	
	// Update is called once per frame

	[SerializeField] private int damage = 1;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Damageable")
			collision.gameObject.GetComponent<Destructable>().Damage(damage);
		Destroy(gameObject);
	}

}
