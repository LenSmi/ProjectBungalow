using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreAttackStartState : GameState
{
    public override void Awake()
    {
        base.Awake();
        SceneChangeManager.IsLoadingDone += StartGame;
    }
    public override void EnterGamestate()
    {
        Debug.Log("Entering state SCA START");
        var sceneManager = GameManager.Instance().SceneChangeManager();
        StartCoroutine(sceneManager.IELoadGameScene(GameScenes.Scene_Score_Attack));

    }

    public override void ExitGamestate()
    {

    }

    private void StartGame()
    {
        StartCoroutine(GameManager.Instance().MinigameManager().StartGame());
    }

}
