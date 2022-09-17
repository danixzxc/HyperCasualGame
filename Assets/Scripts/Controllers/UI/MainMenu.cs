using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]public Animator Animator;

    [Header ("UI references :")]
    [SerializeField] private Image _fillImage;

    [SerializeField] private Transform _finishTransform;
    [SerializeField] private Transform _playerTransform;


    private Vector3 _finishPosition; //hash instead of update

    private float _fullDistance;

    public static bool gameStateShop = false;

    public void PlayGame()
    {
        // Animator.SetBool("GameStarted", true);
        Actions.OnGameStateChange(StateController.gameState.game);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        Actions.OnGameStateChange(StateController.gameState.shopMenu);
        gameStateShop = true;
    }

    public void ExitShop()
    {
        Actions.OnGameStateChange(StateController.gameState.mainMenu);
        gameStateShop = false;
    }

    public void SelectMaterial(int num)
    {
        PlayerPrefs.SetInt("Skin", num);
        Actions.OnGameStateChange(StateController.gameState.changeSkin);
    }

    private void Update()
    {
            UpdateProgressFIll();
    }

    private void Start()
    {//почему выдает ошибку?
     //   Actions.OnGameStateChange(StateController.gameState.mainMenu);
        _finishPosition = _finishTransform.position;
        _fullDistance = GetDistance();
    }

    private void UpdateProgressFIll()
    {
        if (_playerTransform.position.z <= _finishPosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(_fullDistance, 0f, newDistance);
           // if (gameStarted)
                _fillImage.fillAmount = progressValue;
        }
    }

    private float GetDistance()
    {
        return (_finishPosition - _playerTransform.position).sqrMagnitude;
    }
}
