using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController
{
    private protected Animator _animator;

    public AnimationController( Animator animator) 
    {
        _animator = animator;
    }

    public void Start()
    {
        Actions.OnPlayerStateChange += ChangeAnimation;
    }

    private void ChangeAnimation(StateController.playerState playerState)
    { 
        if (playerState == StateController.playerState.running)
            _animator.SetBool("IsRunning", true);

        if (playerState == StateController.playerState.idle)
            _animator.SetBool("IsRunning", false);
    }
}
