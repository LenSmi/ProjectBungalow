using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackEndState : GameState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void EnterGamestate()
    {
        StartCoroutine(sceneChangeManager.IELoadGameScene(GameScenes.Scene_Score_Attack_ScoreScreen));
    }

    public override void ExitGamestate()
    {

    }

}
