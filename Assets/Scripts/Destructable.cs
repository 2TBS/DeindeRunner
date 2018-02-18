using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

	// Use this for initialization
	public const int MAX_HEALTH = 3; 
	private int health = MAX_HEALTH;

	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if(health < 0)
			health = 0;
		float lerp = Mathf.Lerp(0, 255, (float) health / (float) MAX_HEALTH);
		spriteRenderer.color = new Color(255.0f - lerp, lerp	, 0.0f);

		if(health == 0)
			Destroy(gameObject);
	}

	public void Damage(int damage) {
		Debug.Log("here");
		health -= damage;
	}


}
