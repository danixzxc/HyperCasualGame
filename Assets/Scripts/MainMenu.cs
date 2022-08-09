using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool gameOver = false;
    public static bool gameStarted = false;

    public static int materialNum = 0;

    [SerializeField]public Animator Animator;
    public void PlayGame()
    {
        Animator.SetTrigger("GameStarted");
        if (gameOver)
        {
            //Restart current scene
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            //Start the game
            gameStarted = true;
        }
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SelectMaterial(int num)
    {
        materialNum = num;
    }
}
