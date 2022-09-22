using System;

public class StateController 

{ 
    public enum gameState 
    { 
        mainMenu,
        shopMenu,
        game,
        changeSkin
    }
    public enum playerState
    {
        idle,
        running,
        attack
    }
}
public static class Actions
{
    public static Action<StateController.gameState> OnGameStateChange;

    public static Action<StateController.playerState> OnPlayerStateChange;
}

