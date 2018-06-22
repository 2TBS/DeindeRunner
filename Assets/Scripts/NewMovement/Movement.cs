// Movement.cs
// Author: Omar Hossain

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveHorizontal;

	public float moveVertical;

    public float speed;             //Floating point variable to store the player's movement speed.

	public float max_vel;

	private Vector2 previous_dir;

	private Vector2 movement;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	private Collider2D c2d;

	public RaycastHit2D groundRay;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
		c2d = GetComponent<Collider2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
		//Receives input from player
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis ("Vertical");
		movement = new Vector2 (moveHorizontal, moveVertical);
		//Checks to see if the player is changing direction. If s/he is, the horizontal velocity will turn to 0
		if( rb2d.velocity.x != 0 && isGrounded() && 
			( ( (rb2d.velocity.x > 0 && previous_dir.x > moveHorizontal) || (previous_dir.x < moveHorizontal && rb2d.velocity.x < 0) ) 
			|| moveHorizontal == 0 ) )
		{
			Vector2 v = rb2d.velocity;
			v.x = 0f;
			rb2d.velocity = v;
		}
		if( Mathf.Abs(rb2d.velocity.x) < max_vel )
			accelerateHorizontal();
		//print ("Ray: " + groundRay.distance + "  Transform" + transform.position + "  X-Velocity" + rb2d.velocity.x);
		previous_dir = new Vector2(moveHorizontal, moveVertical);
    }

	//Cast a ray downward and checks if it hit something. If it does, it's grounded
	bool isGrounded()
	{
		groundRay = Physics2D.Raycast(transform.position, -Vector2.up, c2d.bounds.extents.y + 0.05f );
		if (groundRay.distance != 0)
			return true;
		return false;
	}

	void accelerateHorizontal()
	{
		rb2d.AddForce (movement * speed);
	}
}