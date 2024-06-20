using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchState : GameState, IGameState
{
    public void EnterGamestate()
    {
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_TrenchArea1);
    }

    public void ExitGamestate()
    {

    }

}
