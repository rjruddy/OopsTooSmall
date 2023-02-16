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
    public Vector3 start_pos = new Vector3(-18, 3.5f, -5);

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = start_pos;
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

        if (this.gameObject.transform.position.y < -12)
        {
            this.gameObject.transform.position = start_pos;
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
            Debug.Log("Jump Pressed and grounded");
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpPower);
            grounded = false;
            jumpPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //check if landed on top of a platform object
        if (collision.collider.CompareTag("ground"))
        {

            grounded = true;
            
        }
    }
}
