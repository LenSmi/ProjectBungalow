using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackSaloonState : GameState, IGameState
{
    public override void EnterGamestate()
    {
        var sceneChangeManager = GameManager.Instance().SceneChangeManager();
        StartCoroutine(sceneChangeManager.IELoadGameScene(GameScenes.Scene_Score_Attack_Saloon));
    }

    public override void ExitGamestate()
    {

    }
}
