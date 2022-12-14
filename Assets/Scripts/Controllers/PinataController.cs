using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataController : MonoBehaviour
{
    [SerializeField] private GameObject _pinata;

    private void Awake()
    {
        Actions.OnPlayerStateChange += PinataSetActive;
    }
    public void Start()
    {
       _pinata.SetActive(false);
    }

    public void PinataSetActive(StateController.playerState playerState)
    {
        if(playerState == StateController.playerState.minigame)
           _pinata.SetActive(true);
    }
}
