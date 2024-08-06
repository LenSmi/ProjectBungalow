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

    public enum PlayerStates
    {
        IDLE,
        MOVING,
        MINNING,
        DASHING

    }

    public enum ResourceType
    {
        PLASTICS,
        JUNK,
        BIOMASS
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

    public const string PlayerSubTag = "PlayerSub";
    public const string ResourceNodeTag = "ResourceNode";
}
