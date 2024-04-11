using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants
{
    public enum GameStates
    {
        LOADING,
        INMENU,
        ACTIVE,
        IDLE,
        PAUSED,
        GAMEOVER
    }

    public enum WorldState
    {
        OVERWORLD,
        TRENCH
    }

    public static readonly List<string> GameLayers = new List<string>
       {
            "Ground", "Resource"
       };


}
