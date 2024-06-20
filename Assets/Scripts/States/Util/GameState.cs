using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class GameState : MonoBehaviour
{
    protected GameManager gameManager;

    virtual public void Awake()
    {
        gameManager = GameManager.Instance();
        Assert.IsTrue(gameManager != null, "Could not find Game Manager");
    }
}
