using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreAttackEndState : GameState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void EnterGamestate()
    {
        var sceneChangeManager = GameManager.Instance().SceneChangeManager();
        Cursor.visible = true;
        StartCoroutine(sceneChangeManager.IELoadGameScene(GameScenes.Scene_Score_Attack_ScoreScreen));
    }

    public override void ExitGamestate()
    {

    }

}
