using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : State
{
    protected float swerveSpeed;
    protected float moveFactor;
    protected float startTouchPostitionX;
    protected float maxSwerveSpeed;
    protected float speed;

    private bool isRunning = false;
    public RunningState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
    {
    }
    public override void Enter()
    {
        Actions.OnPlayerStateChange += ChangeState;

        base.Enter();
        swerveSpeed = 0.0f;
        maxSwerveSpeed = playerController.maxSwerveSpeed;
        speed = playerController.speed;
    }

    public override void Exit()
    {
        base.Exit();
        //character.ResetMoveParams();
    }

    public override void HandleInput()
    {

        base.HandleInput();

        if (Input.GetMouseButtonDown(0))
        {
            startTouchPostitionX = Input.mousePosition.x;
            Actions.OnPlayerStateChange(StateController.playerState.running);
           isRunning = true;
        }

        if (Input.GetMouseButton(0))
        {
            moveFactor = Input.mousePosition.x - startTouchPostitionX;
            startTouchPostitionX = Input.mousePosition.x;

        }

        if (Input.GetMouseButtonUp(0))
        {
            moveFactor = 0f;
            Actions.OnPlayerStateChange(StateController.playerState.idle);
           isRunning = false;
        }

        swerveSpeed = moveFactor * Time.deltaTime * speed;
        swerveSpeed = Mathf.Clamp(swerveSpeed, -maxSwerveSpeed, maxSwerveSpeed);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(isRunning)
        playerController.Swerve(swerveSpeed);
    }

    private void ChangeState(StateController.playerState playerState)
    {
        if (playerState == StateController.playerState.minigame)
        {
            stateMachine.ChangeState(playerController.minigame);
        }
    }
}