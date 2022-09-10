using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Main : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private Collider playerCollider;

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
        playerController = new PlayerController(playerTransform, playerRigidbody);
        cameraController = new CameraController();
        _skinsController = new SkinsController();
        mainMenu = new MainMenu();

        animationController = new AnimationController(animator);

        animationController.Start();

        playerCollider.SendMessage("OnTriggerEnter");

    }

    void Update()
    {
        gameStateShop = mainMenu.GemeStateShop();
        _skinsController.UpdateSkins(Skins);
        cameraController.Update(gameStateShop, gameCamera, shopCamera);
        playerController.Update();
    }
}
