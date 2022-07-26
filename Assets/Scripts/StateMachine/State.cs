using UnityEngine;
public abstract class State
{
    protected PlayerController playerController;
    protected StateMachine stateMachine;

    protected State(PlayerController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {
    }

    public virtual void HandleInput()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}