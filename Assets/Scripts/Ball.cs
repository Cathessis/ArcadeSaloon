using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay; // ball status, ball is moving or not
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gameManager;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.arcadeGameOver)
        {
            Debug.Log("Ball Destroyed");
            Destroy(this.gameObject);
            //return;
        }

        if (!inPlay)
        {
            transform.position = paddle.position; // Sets position with ball and paddle
        }

        if (Input.GetKeyDown(KeyCode.Space) && !inPlay)
        {
            inPlay = true;
            Debug.Log("Pressed Space Bar"); // Test Debug
            rb.AddForce(Vector2.up * speed); // Y axis force to throw ball
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fallCollider")) // are theese same? look documentary (collision.gameObject.CompareTag("fallCollider")) 
        {
            Debug.Log("Ball collided with " + collision.name);
            rb.velocity = Vector2.zero; // Prevents balls moves
            inPlay = false; // With doing false, ball is setting starting position in update function
            gameManager.UpdateLives(-1); // I deleted singletons and left using instance. This way is easy to use.
            Debug.Log("Lives: " + GameManager.lives);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation); // Instantiate is  using for the object creating
            Destroy(newExplosion.gameObject, 1f);

            gameManager.UpdateScore(collision.gameObject.GetComponent<Brick>().points); // I tried to use singleton here but bricks are disappear after using singleton
            gameManager.BrickCounter();
            //Destroy(collision.gameObject);

        }
    }
}
