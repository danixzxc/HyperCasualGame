using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField]public Animator Animator;

    [Header ("UI references :")]
    [SerializeField] private Image _fillImage;

    [SerializeField] private Transform _finishTransform;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] public GameObject _minigameImage;
    [SerializeField] public GUI ui;


    private Vector3 _finishPosition; //hash instead of update

    private float _fullDistance;

    public static bool gameStateShop = false;

    [SerializeField] public TextMeshPro text;

    [SerializeField] public RectTransform minigameRectTransform;


    public void PlayGame()
    {
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
    {
        _finishPosition = _finishTransform.position;
        _fullDistance = GetDistance();
        Actions.OnPlayerStateChange += EnableMinigame;

    }

    private void TweenImage(RectTransform imageRectTransform)
    {
        imageRectTransform.DOLocalMoveX(-imageRectTransform.anchoredPosition.x, 2).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutCubic);
    }

    private void EnableMinigame(StateController.playerState playerState)
    {
        if (playerState == StateController.playerState.minigame)
        {
            _minigameImage.SetActive(true);
            TweenImage(minigameRectTransform);
        }
    }

    public void MinigameTap()
    {
       // Debug.Log(minigameRectTransform.anchoredPosition.x.ToString());
        Actions.OnPlayerStateChange(StateController.playerState.attack);

    }

    private void UpdateProgressFIll()
    {
        if (_playerTransform.position.z <= _finishPosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(_fullDistance, 0f, newDistance);
            _fillImage.fillAmount = progressValue;
        }
    }

    private float GetDistance()
    {
        return (_finishPosition - _playerTransform.position).sqrMagnitude;
    }
}
