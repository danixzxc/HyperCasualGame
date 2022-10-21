using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public void Attack()
    {
            Actions.OnPlayerStateChange(StateController.playerState.minigame);
    }
}
