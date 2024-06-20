using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    public IGameState currentGameState;
    public float underwaterTime;
    public SceneChangeManager sceneChangeManager;
    public GameScenes initalGameScene;

    public static TrenchState trenchState = new TrenchState();
    public static HubState hubState = new HubState();
    public static ScoreAttackStartState scoreAttackStartState = new ScoreAttackStartState();
    public static ScoreAttackEndState scoreAttackEndState = new ScoreAttackEndState();

    public void Start()
    {
#if UNITY_EDITOR
       StartCoroutine(sceneChangeManager.LoadGameScene(initalGameScene));
#endif
    }

    public void TransitionToState(IGameState gameState)
    {
        currentGameState = gameState;
        gameState.EnterGamestate();
        Debug.Log("Transition to state");
    }
}
