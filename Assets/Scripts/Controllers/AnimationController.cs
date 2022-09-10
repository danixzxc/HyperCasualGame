using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController
{
    private protected Animator animator;

    public AnimationController( Animator animator) 
    {
        this.animator = animator;
    }

    public void Start()
    {
        Actions.OnStateChange += ChangeAnimation;
    }

    private void ChangeAnimation(bool isRunning)
    { 
        animator.SetBool("IsRunning", isRunning);
    }
}
