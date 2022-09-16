using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Main : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject[] Skins;

    [SerializeField] private CinemachineVirtualCamera gameCamera;
    [SerializeField] private CinemachineVirtualCamera shopCamera;

    [SerializeField] private Animator animator;

    private SkinsController _skinsController;
    private MainMenu mainMenu;
    private CameraController cameraController;
    private AnimationController animationController;
    private PlayerController playerController;

    private bool gameStateShop;
    void Start()
    {
        mainMenu = new MainMenu();
        playerController = new PlayerController(playerTransform);
        cameraController = new CameraController();
        _skinsController = new SkinsController();

        animationController = new AnimationController(animator);

        animationController.Start();

    }

    void Update()
    {
        gameStateShop = mainMenu.GemeStateShop();
        _skinsController.UpdateSkins(Skins);
        cameraController.Update(gameStateShop, gameCamera, shopCamera);
        playerController.Update();
    }
}
