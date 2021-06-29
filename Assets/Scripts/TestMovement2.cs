using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement2 : MonoBehaviour
{
    
    public float speed; //Paddle speed is public so I can set the comfortable speed for me 
    public float jump; // Jump speed
    private bool isFacingRight = true; // Running direction
    private float moveDirection;
    private bool isJump = false;

    private Rigidbody2D rb;

    
    private void Awake() // Awake is running after all objects are initialize
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
        }
        
    }

    private void PlayerMove()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        if (isJump)
        {
            rb.AddForce(new Vector2(0f, jump));
            //rb.AddForce(Vector2.up * jump); // Y axis force to throw ball
        }
        
        isJump = false;
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}