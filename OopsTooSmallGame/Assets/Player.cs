using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigbod;
    public float walkSpeed = 5f;
    public float jumpPower = 10f;
    bool grounded;
    bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        rigbod = this.GetComponent<Rigidbody2D>();
        grounded = false;
        jumpPressed = false;
    }

    // Update is called once per frame -- used to detect key presses
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            jumpPressed = true;
        }
    }

    // used to implement movement
    void FixedUpdate()
    {
        TryMove();
    }

    void TryMove()
    {
        // movement achieved by manipulating velocity
        float horizontal = Input.GetAxis("Horizontal");
        rigbod.velocity = new Vector2(horizontal * walkSpeed, rigbod.velocity.y);

        if (jumpPressed && grounded)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpPower);
            grounded = false;
            jumpPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if landed on top of a platform object
        if (collision.collider.CompareTag("ground") && collision.transform.position.y < this.transform.position.y)
        {
            grounded = true;
        }
    }
}
