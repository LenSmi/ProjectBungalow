using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class GameState : MonoBehaviour
{
    protected GameManager gameManager;

    virtual protected void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        Assert.IsTrue(gameManager != null, "Could not find Game Manager");
    }
}
