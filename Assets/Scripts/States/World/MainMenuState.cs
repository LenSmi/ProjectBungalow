using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameState
{
    public override void EnterGamestate()
    {
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_Main_Menu);
    }

    public override void ExitGamestate()
    {

    }

}
