using UnityEngine;


    public class MinigameState : State
    {
    public MinigameState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
        }

        public override void Enter()
        {
        base.Enter();
        //Pinata.SetActive(true); TODO instead of PinataAnimationController
        }

    public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();

        if (Input.GetMouseButtonDown(0))
        {
            playerController.Attack();
        }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
