using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class CameraController
{
    private CinemachineVirtualCamera _gameCamera;
    private CinemachineVirtualCamera _shopCamera;

    public CameraController(CinemachineVirtualCamera gameCamera, CinemachineVirtualCamera shopCamera)
    {
        _gameCamera = gameCamera;
        _shopCamera = shopCamera;
    }
    public void Start()
    {
        Actions.OnGameStateChange += UpdateCameras;
    }
 
    public void UpdateCameras(StateController.gameState gameState) 
    { 
        if (gameState == StateController.gameState.mainMenu)
        {
            _gameCamera.Priority = 10;
            _shopCamera.Priority = 1;
        }
        if (gameState == StateController.gameState.shopMenu)
        {
            _gameCamera.Priority = 1;
            _shopCamera.Priority = 10;
        }
    }
}
