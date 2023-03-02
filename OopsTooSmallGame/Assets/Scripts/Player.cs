using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigbod;
    public float walkSpeed;
    public float jumpPower;
    public Transform groundCheck;
    public Transform wallCheck;
    public float wallCheckRadius;
    public float groundCheckRadius;
    public float wallSlideSpeed;
    public LayerMask groundLayer;
    public float deathLowBound;

    private bool isGrounded;
    private bool isWalled;
    private bool isWallJumping;
    private bool jumpPressed;
    private bool canWallJump;
    private float horizontal;
    private int health;
    private Vector2 wallNormal;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
        rigbod = this.GetComponent<Rigidbody2D>();
        health = 3;
    }

    // Update is called once per frame -- used to detect key presses
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
                                            groundCheckRadius,
                                            groundLayer);
        isWalled = Physics2D.OverlapCircle(wallCheck.position,
                                            wallCheckRadius,
                                            groundLayer);
        bool upPressed = Input.GetKey("up") || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        if (upPressed && (isGrounded || isWalled))
        {
            jumpPressed = true;
        }
         //If lives being lost needs to be implemented, add it within this
         //if statement
        if(this.gameObject.transform.position.y < deathLowBound)
        {
            //DecreaseHealth();
            if (health == 0)
            {

            }
            this.gameObject.transform.position = startPos;
        }
    }

    // used to implement movement
    void FixedUpdate()
    {
        TryMove();
        TryJump();
        TryWallBehavior();
    }

    private void TryMove()
    {
        // movement achieved by manipulating velocity
        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        rigbod.velocity = new Vector2(horizontal * walkSpeed, rigbod.velocity.y);

        //TryJump();
    }

    private void TryJump()
    {
        if (jumpPressed && isGrounded)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpPower);
            jumpPressed = false;
        }
        if (jumpPressed && isWalled)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpPower);
            jumpPressed = false;
        }
    }

    private void TryWallBehavior()
    {
        //wall slide
        if (isWalled && !isWallJumping)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, Mathf.Clamp(rigbod.velocity.y, -wallSlideSpeed, 100));
        }
    }

    public void DecreaseHealth()
    {
        health -= 1;
        HealthUI.SetText(string.Format("Player lives: " + health));
    }

    public int GetHealth()
    {
        return health;
    }

}
