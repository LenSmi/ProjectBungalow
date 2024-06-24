using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class GameState : MonoBehaviour, IGameState
{
    protected GameManager gameManager;
    protected SceneChangeManager sceneChangeManager;

    virtual public void Awake()
    {
        gameManager = GameManager.Instance();
        sceneChangeManager = GameManager.Instance().SceneChangeManager();
        Assert.IsTrue(gameManager != null, "Could not find Game Manager");
    }

    public abstract void EnterGamestate();


    public abstract void ExitGamestate();

}
