using System;

public class StateController 

{ 
    public enum gameState 
    { 
        mainMenu,
        shopMenu,
        game
    }
    public enum playerState
    {
        idle,
        running,
        dancing
    }
}
public static class Actions
{
    public static Action<bool> OnStateChange;
}
