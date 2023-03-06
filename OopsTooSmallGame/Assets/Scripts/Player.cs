using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public AudioClip jumpSound;
    public AudioSource audioSource;

    public AudioClip deathSound;

    Rigidbody2D rigbod;
    public float walkSpeed;
    public float jumpPower;
    public float wallJumpPower;
    public float wallCheckRadius;
    public float groundCheckRadius;
    public float wallSlideSpeed;
    public float wjTime;
    public float deathLowBound;
    public float jumpCooldown = 1f;

    public Collector starCounter;
    public EventManager evmanScript;
    public HealthUI health;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform wallCheck;

    private Transform wallTransform;
    private bool isGrounded;
    private bool isWalled;
    private bool isWallJumping;
    private bool jumpPressed;
    private bool canJump;
    private bool freeFalling;

    private float horizontal;
    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
        rigbod = this.GetComponent<Rigidbody2D>();
        //health = 3;
        audioSource = GetComponent<AudioSource>();
        jumpSound = Resources.Load<AudioClip>("Sounds/jump");
        canJump = true;
        freeFalling = false;
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
        
        if (isGrounded) {
            freeFalling = false;
        }

        if (upPressed && (isGrounded || isWalled))
        {
            jumpPressed = true;
        }
         
        if(this.gameObject.transform.position.y < deathLowBound)
        {

            SoundManager.Instance.PlayDeathSound(deathSound);
            if (health.Death())
            {
                SceneManager.LoadScene("LoseScreen");
            }
            

            this.gameObject.transform.position = startPos;
        }
    }

    // used to implement movement
    void FixedUpdate()
    {
        if (!isWallJumping)
        {
            TryMove();
            TryJump();

        }
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





        //this makes the player fall normally when wall jumping without input
        if (!(freeFalling && horizontal == 0)) {
            rigbod.velocity = new Vector2(horizontal * walkSpeed, rigbod.velocity.y);
        } 
    }

    private void TryJump()
    {

        if (!canJump) {
            jumpPressed = false;
            return;
        }

        else { 

            if (jumpPressed && isGrounded)

            {
                rigbod.velocity = new Vector2(rigbod.velocity.x, jumpPower);
                jumpPressed = false;

                audioSource.PlayOneShot(jumpSound);

                // Debug.Log("jump from ground");
                canJump = false;
                Invoke("ReenableJump", jumpCooldown);

                return;
            }
        
            if (jumpPressed && isWalled)
            {

                
                isWallJumping = true;
                float modifier = wallJumpPower;
                //RIGHT WALL:
                if (wallTransform.position.x > this.transform.position.x)
                {
                    modifier = -modifier;
                }
                // rigbod.AddForce(new Vector2(modifier, jumpPower * 10));
                rigbod.velocity = new Vector2(modifier, jumpPower);
                freeFalling = true;

                Invoke("DontWallJump", wjTime);

                audioSource.PlayOneShot(jumpSound);

                canJump = false;


                Invoke("ReenableJump", jumpCooldown);

                return;

            }
        }
        return;
        
    }


    private void ReenableJump() {

        canJump = true;
    }

    private void TryWallBehavior()
    {
        //wall slide
        if (isWalled && !isWallJumping)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, Mathf.Clamp(rigbod.velocity.y, -wallSlideSpeed, 100));
        }
    }

    private void DontWallJump()
    {
        isWallJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wallTransform = collision.collider.GetComponent<Transform>();
        /*
        if (isWalled)
        {
            wallTransform = collision.collider.GetComponent<Transform>();
            /*
            //check if collision is a platform
            if (collision.collider.GetComponent<SortingLayer>().ToString() == "Ground")
            {
                Debug.Log("platform collision detected");
                wall = collision.collider.GetComponent<GameObject>();
            }
            
        }
        */


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star"))
        {
            starCounter.starCollected();
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("key"))
        {
            evmanScript.CollectedKey();
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("boss-head"))
        {
            SceneManager.LoadScene("WinScreen");
        } else if (collision.gameObject.CompareTag("boss-body"))
        {
            if (health.Death())
            {
                SceneManager.LoadScene("LoseScreen");
            }
            this.gameObject.transform.position = startPos;
        }
    }
   
}
