using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitMachine()
    {
        //Debug.Log("Game has started");
        SceneManager.LoadScene("C6ArcadeSaloon");
        //GameManager.score = 0;

    }
    public void StartGameHome()
    {
        //Debug.Log("Game has started");
        SceneManager.LoadScene("B1Home");
        //GameManager.score = 0;

    }
    public void HowToPlay()
    {
        //Debug.Log("Game has started");
        SceneManager.LoadScene("HowToPlay");
        //GameManager.score = 0;

    }
    public void ArcadeAfterPlay()
    {
        //Debug.Log("Game has started");
        SceneManager.LoadScene("B1Home");
        //GameManager.score = 0;

    }

    public void MainMenu()
    {
        //Debug.Log("Game has started");
        SceneManager.LoadScene("MainMenu");
        //GameManager.score = 0;

    }
    public void StartGame()
    {
        Debug.Log("Game has started");
        SceneManager.LoadScene("Level1");
        GameManager.score = 0;

    }

    public void GameOver()
    {
        Debug.Log("Game over level manager test");
        SceneManager.LoadScene("ArcadeGameOverLevel");
        GameManager.score = 0;
        GameManager.lives = 3;
    }
}
