using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game");
        GameManager.Instance().SceneChangeManager().LoadGameScene(GameScenes.Scene_Score_Attack_Saloon);
    }

    public void ExitGame()
    {
       Application.Quit();
    }
}
