public class MenuState : State
{

    public MenuState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Actions.OnGameStateChange += ChangeState;
    }

    private void ChangeState(StateController.gameState playerState)
    {
        if(playerState == StateController.gameState.game)
        stateMachine.ChangeState(playerController.running);
    }
}

