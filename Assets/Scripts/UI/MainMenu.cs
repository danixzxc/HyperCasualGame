using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField]public Animator Animator;

    [Header ("UI references :")]
    [SerializeField] private Image fillImage;

    [SerializeField] private Transform finishTransform;
    [SerializeField] private Transform playerTransform;


    private Vector3 finishPosition; //hash instead of update

    private float fullDistance;

    public static bool gameStateShop = false;



    //private bool _gameStarted;
    //private Transform _finishTransform;
    //private Transform _playerTransform;

    // public MainMenu(bool gamestarted, Transform finishTransform, Transform playerTransform)
    //{
    //  gameStarted = gamestarted;
    //     finishTransform = finishTransform;
    //     playerTransform = playerTransform;
    // }

    public void PlayGame()
    {
        Animator.SetBool("GameStarted", true);
       // gameStarted = true;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        gameStateShop = true;
    }

    public void ExitShop()
    {
        gameStateShop = false;
    }

    public void SelectMaterial(int num)
    {
        PlayerPrefs.SetInt("Skin", num);
    }

    public void Update()
    {
            UpdateProgressFIll();
    }

    public void Start()
    {
        finishPosition = finishTransform.position;
        fullDistance = GetDistance();
    }

    private void UpdateProgressFIll()
    {
        if (playerTransform.position.z <= finishPosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
          //  if (gameStarted)
                fillImage.fillAmount = progressValue;
        }
    }

    private float GetDistance()
    {
        return (finishPosition - playerTransform.position).sqrMagnitude;
    }

    public bool GemeStateShop()
    {
        return gameStateShop;
    }
}
