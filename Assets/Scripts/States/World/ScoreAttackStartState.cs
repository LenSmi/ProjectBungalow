using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackStartState : GameState
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void EnterGamestate()
    {
        Debug.Log("Entering state SCA START");
        StartCoroutine(GameManager.Instance().SceneChangeManager().IELoadGameScene(GameScenes.Scene_Score_Attack));
    }

    public override void ExitGamestate()
    {

    }

}
