using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackStartState : GameState, IGameState
{
    public override void Awake()
    {
        base.Awake();
    }
    public void EnterGamestate()
    {
        Debug.Log("Entering state SCA START");
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_Score_Attack);
    }

    public void ExitGamestate()
    {

    }

}
