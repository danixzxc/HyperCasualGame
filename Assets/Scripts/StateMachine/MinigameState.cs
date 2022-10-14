using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MinigameState : State
    {

    MainMenu mainMenu = new MainMenu();
    public MinigameState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
        }

        public override void Enter()
        {
        base.Enter();
        Debug.Log("бью пиньятку)) ^_^");

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
            mainMenu.MinigameTap();
        }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
