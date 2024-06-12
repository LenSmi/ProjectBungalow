using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public GameConstants.GameStates gameStates;
    public GameConstants.WorldState worldStates;

    public static GameManager Instance() { return instance_; }
    public Cargo cargo() { return cargo_; }
    public SceneChangeManager sceneChangeManager() { return sceneChangeManager_; }
    public MinigameManager minigameManager() { return minigameManager_; }

    private static GameManager instance_;
    [SerializeField]
    private Cargo cargo_;
    [SerializeField]
    private SceneChangeManager sceneChangeManager_;
    [SerializeField]
    private MinigameManager minigameManager_;


    private void Awake()
    {
        instance_ = this;
    }
}
