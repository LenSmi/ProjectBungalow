using System;
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
        Cursor.visible = false;
    }

    public override void EnterGamestate()
    {
        Debug.Log("Entering state SCA START");
        var sceneManager = GameManager.Instance().SceneChangeManager();
        StartCoroutine(sceneManager.IELoadGameScene(GameScenes.Scene_Score_Attack));

        if (SceneManager.GetSceneByName(GameScenes.Scene_Score_Attack.ToString()).isLoaded)
        {
            var minigameManager = GameManager.Instance().MinigameManager();
            StartCoroutine(minigameManager.StartGame());
        }

    }

    public override void ExitGamestate()
    {

    }

    private void StartGame()
    {

        if (SceneManager.GetSceneByName(GameScenes.Scene_Score_Attack.ToString()).isLoaded)
        {
            try
            {
                var minigameManager = GameManager.Instance().MinigameManager();
                StartCoroutine(minigameManager.StartGame());
            }
            catch(Exception ex) 
            { 
                Debug.LogWarning("Could not start game: " + ex);
            }

        }
    }

}
