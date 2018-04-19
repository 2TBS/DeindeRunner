using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterGravity : MonoBehaviour {

	public float fallMult = 3.5f;
	public float lowJumpMult = 2.5f;
	
	Rigidbody2D rb;

	[SerializeField]
    private InputManager input;

	private bool jumpButtonDown;
	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		jumpButtonDown = Input.GetButton("Jump");
	}

	// Don't read Inputs in FixedUpdate() and don't do physics in Update()
	void FixedUpdate() {
		if(rb.velocity.y < .5) {
			rb.gravityScale = fallMult;
		} else if (rb.velocity.y > 0 && !jumpButtonDown) {
				rb.gravityScale = lowJumpMult;
		} else {
			rb.gravityScale = 1;
		}
	}

}
