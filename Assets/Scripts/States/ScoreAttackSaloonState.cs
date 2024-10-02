using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackSaloonState : GameState, IGameState
{
    public override void EnterGamestate()
    {
        var sceneChangeManager = GameManager.Instance().SceneChangeManager();
        Cursor.visible = false;
        sceneChangeManager.LoadGameScene(GameScenes.Scene_Score_Attack_Saloon);
    }

    public override void ExitGamestate()
    {

    }
}
