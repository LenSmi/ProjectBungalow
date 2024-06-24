using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackSaloonState : GameState, IGameState
{
    public override void EnterGamestate()
    {
        StartCoroutine(GameManager.Instance().SceneChangeManager().IELoadGameScene(GameScenes.Scene_Score_Attack_Saloon));
    }

    public override void ExitGamestate()
    {

    }
}
