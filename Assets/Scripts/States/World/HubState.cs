using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubState : GameState, IGameState
{
    public override void Awake()
    {
        base.Awake();
    }
    public void EnterGamestate()
    {
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_Hub);
    }

    public void ExitGamestate()
    {

    }

}
