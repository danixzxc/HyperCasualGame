using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class CameraController : MainMenu // для gamestarted и gameStateShop
{

    [SerializeField] private CinemachineVirtualCamera gameCamera;
    [SerializeField] private CinemachineVirtualCamera shopCamera;

    void Update()
    { //проверка каждый кадр, лучше подписываться на изменения Action и тогда менять приоритет
        if (!gameStateShop)
        {
            gameCamera.Priority = 10;
            shopCamera.Priority = 1;
        }
        if (gameStateShop)//enum игровых состояний сделать
        {
            //возможно ещё камеры сделать и тогда код переписать, пока что кастыль
            gameCamera.Priority = 1;
            shopCamera.Priority = 10;
        }
    }
}
