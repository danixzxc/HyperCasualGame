using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Main : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private GameObject[] _skins;

    [SerializeField] private CinemachineVirtualCamera _gameCamera;
    [SerializeField] private CinemachineVirtualCamera _shopCamera;

    [SerializeField] private Animator _animator;

    private SkinsController _skinsController;
    private MainMenu _mainMenu;
    private CameraController _cameraController;
    private AnimationController _animationController;
    private PlayerController _playerController;
    void Start()
    {
        _mainMenu = new MainMenu();
        _playerController = new PlayerController(_playerTransform);
        _cameraController = new CameraController(_gameCamera, _shopCamera);
        _skinsController = new SkinsController(_skins);
        _animationController = new AnimationController(_animator);

        _animationController.Start();
        _skinsController.Start();
        _cameraController.Start();
        _playerController.Start();
    }

    void Update()
    {
        _playerController.Update();
    }
}
