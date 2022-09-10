using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class CameraController// : MainMenu
{

 //  private CinemachineVirtualCamera gameCamera;
  // private CinemachineVirtualCamera shopCamera;


   public void Update( bool gameStateShop, CinemachineVirtualCamera gameCamera, CinemachineVirtualCamera shopCamera) 
    { 
        if (!gameStateShop)
        {
            gameCamera.Priority = 10;
            shopCamera.Priority = 1;
        }
        if (gameStateShop)
        {
            gameCamera.Priority = 1;
            shopCamera.Priority = 10;
        }
    }
}
