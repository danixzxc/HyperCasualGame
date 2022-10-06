using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{

    public MenuState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter(); //TODO бла бла бла обнулить игрока анимация idle двигаться нельзя у нас открыта менюшка.

        Actions.OnGameStateChange += ChangeState;

        Debug.Log("подписался");
    }

   /* public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //playerController.Move(verticalInput * speed, horizontalInput * rotationSpeed);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (false) //TODO если дошел до финиша
        {
            stateMachine.ChangeState(playerController.minigame);
        }
    }*/

    private void ChangeState(StateController.gameState playerState)
    {
        //if (playerState == StateController.gameState.game)
        if(playerState == StateController.gameState.game)
        stateMachine.ChangeState(playerController.running);
    }
}

