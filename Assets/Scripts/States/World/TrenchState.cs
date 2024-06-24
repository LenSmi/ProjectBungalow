using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchState : GameState
{
    public override void EnterGamestate()
    {
        StartCoroutine(GameManager.Instance().SceneChangeManager().IELoadGameScene(GameScenes.Scene_TrenchArea1));
    }

    public override void ExitGamestate()
    {

    }

}
