using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestruction : MonoBehaviour {

	private PlayerMovement playerMovement;
	[SerializeField] private Transform projectile;
	[Range(0, 15)] public float firePower = 15.0f;
	private float time;
	public bool destructionPowerUpOn;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement>();
		destructionPowerUpOn = false;
		time = 0;
	}

	/*void Update() {
		if(destructionPowerUpOn) {
			time += Time.deltaTime;
			if(time > seconds) {
				time = 0;
				//Set Destruction back to OG Destruction
			}
		}
		else {time = 0;}
	}*/

	public void Shoot() {
        Transform clone = Instantiate(projectile, new Vector2(transform.position.x + (playerMovement.playerSize.x * 2f/3f), transform.position.y), 
			projectile.rotation);
		clone.GetComponent<Rigidbody2D>().velocity = Vector2.right * firePower;
		Destroy(clone.gameObject, 10.0f);
    }

	public void PowerUpDestruction(float destructionIncrease, float duration) {
		//destruction += destructionIncrease;
	}
}
