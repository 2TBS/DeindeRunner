using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveHorizontal;

	public float moveVertical;

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	public RaycastHit2D groundRay;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis ("Vertical");
		int x = 9;
		groundRay = Physics2D.Raycast(transform.position, -Vector2.up);
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        rb2d.AddForce (movement * speed);
		//print ("Ray: " + groundRay.point + "  Transform" + transform.position);
    }
}