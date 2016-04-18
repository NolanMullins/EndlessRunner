using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncDist;
    private float speedIncDistStore;
    private float speedMileStoneCount;
    private float speedMileStoneCountStore;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myBody;

    private bool grounded;
    public LayerMask whatIsGround;

    //private Collider2D myCollider;
    public Transform groundCheck;
    public float groundCheckRadius;

    //animations
    private Animator myAnimator;

    //manager
    public GameManager gameManager;

    //touch input
    private int numTouchesLastFrame;

    //sounds
    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMileStoneCount = speedIncDist;
        moveSpeedStore = moveSpeed;
        speedMileStoneCountStore = speedMileStoneCount;
        speedIncDistStore = speedIncDist;

        stoppedJumping = true;
        canDoubleJump = true;
        numTouchesLastFrame = Input.touchCount;
    }
	
	// Update is called once per frame
	void Update () {

        //check if the players hitting ground
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMileStoneCount)
        {
            speedMileStoneCount += speedIncDist;
            speedIncDist = speedIncDist * speedMultiplier;
            moveSpeed *= speedMultiplier;
        }

        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || numTouchesLastFrame < Input.touchCount)
        {
            if (grounded)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = true;
                jumpSound.Play();
            } 
            else if (canDoubleJump)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        //holding jump
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || numTouchesLastFrame == Input.touchCount) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || numTouchesLastFrame > Input.touchCount)
        {
            stoppedJumping = true;
            jumpTimeCounter = 0;
        }

        //touch
        numTouchesLastFrame = Input.touchCount;

        myAnimator.SetFloat("Speed", myBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            deathSound.Play();
            gameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMileStoneCount = speedMileStoneCountStore;
            speedIncDist = speedIncDistStore;
        }
    }
}
