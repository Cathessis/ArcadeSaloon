using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameManager gameManager;


    float leftScreenEdge = -4.77f;    // My borders
    float rightScreenEdge = 4.77f;
    public float speed; //Paddle speed is public so I can set the comfortable speed for me 

    //[SerializeField] float ScreenSize = 9.54f;
    /*
    private Camera mainCamera;
    private float paddleInitialY;
    private float paddleWidth = 240;
    private float paddleY;
    private SpriteRenderer SprtRend;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        //For mouse control, this code will be use.
        mainCamera = FindObjectOfType<Camera>();
        paddleInitialY = this.transform.position.y;
        SprtRend = GetComponent<SpriteRenderer>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.arcadeGameOver)
        {
            this.speed = 0;
        }

        PaddleMovemenetKeyboard();
        //PaddleMovementMouse(); //I couldn't use keyboard and mouse same time thus I have to choose one.
    }
    void PaddleMovemenetKeyboard()
    {
        float horizontal = Input.GetAxis("Horizontal"); //Input
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); // Paddle movement

        // Paddle left and right border
        if (transform.position.x < leftScreenEdge) 
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }

        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }

    void PaddleMovementMouse()
    {
        /*
        float paddleShift = ((paddleWidth - ((paddleWidth / 2) * this.SprtRend.size.x)) / 2);                      //not working, couldn't figure out
        float myLeftWall = leftWall - paddleShift;
        float myRightWall = rightWall + paddleShift;
        float mousePositionPixelx = Mathf.Clamp(Input.mousePosition.x, myLeftWall, myRightWall);
        float mousePositionWorldx = (mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixelx, 0 , 0)).x);
        this.transform.position = new Vector3(mousePositionWorldx, paddleInitialY, 0);
        */

        /*
        float mousePosUnit = Input.mousePosition.x / Screen.width * ScreenSize;
        Vector2 pedalPozisyonu = new Vector2(mousePosUnit, transform.position.y);
        transform.position = pedalPozisyonu;

        mousePosUnit = Mathf.Clamp(mousePosUnit, leftWall, rightWall);
        transform.position = new Vector2(mousePosUnit, transform.position.y);
        */
    }
}
