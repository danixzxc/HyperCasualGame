using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : PlayerController
{
    public bool gameOver = false;

    public static int materialNum = 0;

    [SerializeField]public Animator Animator;


    public void PlayGame()
    {
        Animator.SetTrigger("GameStarted");
        gameStarted = true;
        // if (gameOver)
        // {
        //     //Restart current scene
        //     Scene scene = SceneManager.GetActiveScene();
        //     SceneManager.LoadScene(scene.name);
        // }
        // else
        // {
        //     //Start the game
        //     gameStarted = true;
        // }
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SelectMaterial(int num)
    {
        materialNum = num;
    }

    private void Update() 
    
    {
        MoveProgressBar();
    }

    private void MoveProgressBar()
    {
        float fullLength = playerStartPosition.position.x - finishPosition.position.x;


    }
}
