using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Manages the movment of the player around the map.
///Attach to Player object.
public class PL_Movement : MonoBehaviour {
	///Player number, either 1 or 2
	public int playerNo;

	private const float DEFAULT_MOVE_SPEED = 0.5f;

	///Key inputs. 0=jump, 1=left, 2=right
	private KeyCode[] inputs;

	// Use this for initialization
	void Start () {
		inputs = (playerNo == 1)
			? new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.D}
			: new KeyCode[] { KeyCode.I, KeyCode.J, KeyCode.L };
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(inputs[0]))
			Jump();
		if(Input.GetKey(inputs[1]))
			Move(-DEFAULT_MOVE_SPEED);
		if(Input.GetKey(inputs[2]))
			Move(DEFAULT_MOVE_SPEED);
			
	}

	///Player jumping
	void Jump () {

	}

	///Left-right movement
	void Move(float moveSpeed) {
		transform.Translate(Vector2.right * moveSpeed);
	}
}
