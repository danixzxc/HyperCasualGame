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
            _animator.SetFloat("Velocity", 1f);

        if (playerState == StateController.playerState.idle)
            _animator.SetFloat("Velocity", 0f);

        if (playerState == StateController.playerState.attack)
            _animator.SetTrigger("Attack");
    }
}
