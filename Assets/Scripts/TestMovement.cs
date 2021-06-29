using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    public float speed; //Paddle speed is public so I can set the comfortable speed for me 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        PaddleMovemenetKeyboard();

    }
    void PaddleMovemenetKeyboard()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); // Paddle movement
    }
}