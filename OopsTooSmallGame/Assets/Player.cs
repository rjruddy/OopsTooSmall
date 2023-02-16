using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigbod;
    public float walkSpeed = 5f;
    public float jumpPower = 10f;
    public Transform groundCheck;
    public Transform wallCheck;
    public float wallCheckRadius;
    public float groundCheckRadius;
    public float wallSlideSpeed;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isWalled;
    private bool jumpPressed;
    private bool canWallJump;
    private float horizontal;
    private Vector2 wallNormal;

    // Start is called before the first frame update
    void Start()
    {
        rigbod = this.GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown("up") && isGrounded)
        {
            jumpPressed = true;
        }
    }

    // used to implement movement
    void FixedUpdate()
    {
        TryMove();
        TryJump();
        TryWallSlide();
    }

    private void TryMove()
    {
        // movement achieved by manipulating velocity
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } else if (horizontal < 0)
        {
            transform.localScale = new Vector3((-1)*transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
    }

    private void TryWallSlide()
    {
        if (isWalled)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, Mathf.Clamp(rigbod.velocity.y, -wallSlideSpeed, 100));
        }
    }

    private void TryWallJump()
    {

    }
}
