using UnityEngine;
using System.Collections;
 
[System.Serializable]
public class Game { 
 
    public static Game current;
    public Player player;
    public Material material;
    
    
    public Game () {
        player = new Player();
    }
         
}