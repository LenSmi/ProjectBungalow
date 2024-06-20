using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public GameConstants.GameStates gameStates;
    public GameConstants.WorldState worldStates;

    public static GameManager Instance() { return instance_; }
    private static GameManager instance_;
    public Cargo cargo() { return cargo_; }
    [SerializeField]
    private Cargo cargo_;
    public SceneChangeManager SceneChangeManager() { return _sceneChangeManager; }
    [SerializeField]
    private SceneChangeManager _sceneChangeManager;
    public MinigameManager MinigameManager() { return _minigameManager; }
    [SerializeField]
    private MinigameManager _minigameManager;
    public WorldStateManager WorldStateManager() { return _worldStateManager; }
    [SerializeField]
    private WorldStateManager _worldStateManager;
    public PlayerStateManager PlayerStateManager() { return _playerStateManager; }
    [SerializeField]
    private PlayerStateManager _playerStateManager;
    public UIManager UIManager() { return _uiManager; }
    [SerializeField]
    private UIManager _uiManager;





    private void Awake()
    {
        instance_ = this;
    }
}
