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

    [Header ("UI references :")]
    [SerializeField] private Image fillImage;
    [SerializeField] private Text uiStartText;
    [SerializeField] private Text uiFinishText;

    private Vector3 finishPosition;//кэширование константы чтобы не вызывать finish.position каждый кадр


    private float fullDistance;

    public static bool gameStateShop = false;

    public void PlayGame()
    {
        Animator.SetTrigger("GameStarted");
        gameStarted = true;
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
        materialNum = num;
    }

    private void Update()
    {
            UpdateProgressFIll();
    }

    private void Start()
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
            if (gameStarted)
                fillImage.fillAmount = progressValue;
        }
    }

    private float GetDistance()
    {
        return (finishPosition - playerTransform.position).sqrMagnitude;
    }    
}
