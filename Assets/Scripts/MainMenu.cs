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

    [SerializeField]private GameObject PlayerIcon;

    private float fullLength;

    private float finalPositionX = 500f;


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

    private void Start()
    {
        fullLength = finishPosition.position.x - playerStartPosition.position.x;    // старт и финиш позиции есть у всех классов, сделать ненаследуемыми
    }

    private void MoveProgressBar()
    {
        if (gameStarted)
        PlayerIcon.transform.position += new Vector3(10 * Time.deltaTime, 0, 0);

        // PlayerIcon.transform.position += new Vector3(((finishPosition.position.x - playerStartPosition.position.x) / fullLength * finalPositionX - 250), 0, 0);
    }
}
