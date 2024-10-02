using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubState : GameState
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void EnterGamestate()
    {
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_Hub);
    }

    public override void ExitGamestate()
    {

    }

}
