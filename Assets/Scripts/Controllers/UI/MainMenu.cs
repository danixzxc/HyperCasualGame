using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]public Animator Animator;

    [Header ("UI references :")]
    [SerializeField] private Image fillImage;

    [SerializeField] private Transform finishTransform;
    [SerializeField] private Transform playerTransform;


    private Vector3 finishPosition; //hash instead of update

    private float fullDistance;

    public static bool gameStateShop = false;


    public bool gameStarted = false;

    public void PlayGame()
    {
       // Animator.SetBool("GameStarted", true);
       gameStarted = true;
        Debug.Log(gameStarted);
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
            if (gameStarted)
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
