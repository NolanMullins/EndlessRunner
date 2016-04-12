using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myBody;

    public bool grounded;
    public bool doubleJump;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        doubleJump = false;
        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //check if the players hitting ground
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                doubleJump = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
            else if (!doubleJump)
            {
                doubleJump = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
	}
}
