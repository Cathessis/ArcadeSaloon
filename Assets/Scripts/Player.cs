using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int nextScene;
    public int previousScene;
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
        nextScene = SceneManager.GetActiveScene().buildIndex + 1; // Loads next scene 
        previousScene = SceneManager.GetActiveScene().buildIndex - 1; // Loads previous scene
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rightWall"))
        {
            SceneManager.LoadScene(nextScene);
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("leftWall"))
        {
            SceneManager.LoadScene(previousScene);
            //Debug.Log("Player collided with leftWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("pillow"))
        {
            SceneManager.LoadScene("EndDay");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("garbage"))
        {
            SceneManager.LoadScene("B7_GameOver");  
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("arcade"))
        {
            SceneManager.LoadScene("ArcadeStartLevel");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("HR"))
        {
            SceneManager.LoadScene("B2_Street1");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S1L"))
        {
            SceneManager.LoadScene("C1Home");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S1R"))
        {
            SceneManager.LoadScene("B3_Street2");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S2L"))
        {
            SceneManager.LoadScene("C2_Street1");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S2R"))
        {
            SceneManager.LoadScene("B4_Street3");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S3L"))
        {
            SceneManager.LoadScene("C3_Street2");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S3R"))
        {
            SceneManager.LoadScene("B5_Street4");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S4L"))
        {
            SceneManager.LoadScene("C4_Street3");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("S4R"))
        {
            SceneManager.LoadScene("B6_ArcadeSaloon");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }

        if (collision.CompareTag("ARSL"))
        {
            SceneManager.LoadScene("C5_Street4");
            //Debug.Log("Player collided with rightWall");
            rb.velocity = Vector2.zero; // Prevents player moves
        }
    }
}