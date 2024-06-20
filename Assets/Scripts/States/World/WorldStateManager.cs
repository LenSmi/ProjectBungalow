using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameStates
{
    Loading,
    Hub,
    Trench,
    ScoreAttackSaloon,
    ScoreAttackStart,
    ScoreAttackEnd,
}

public class WorldStateManager : MonoBehaviour
{
    public EGameStates initialGameState;
    [HideInInspector]
    public EGameStates gameStates;
    public IGameState currentGameState;
    public float underwaterTime;
    public SceneChangeManager sceneChangeManager;
    public GameObject stateObject;

    public LoadingState loadingState = new LoadingState();
    public TrenchState trenchState = new TrenchState();
    public HubState hubState = new HubState();
    public ScoreAttackStartState scoreAttackStartState = new ScoreAttackStartState();
    public ScoreAttackEndState scoreAttackEndState = new ScoreAttackEndState();

    public void Start()
    {
#if UNITY_EDITOR
        TransitionToState(initialGameState);
#endif
    }

    public void TransitionToState(EGameStates gameState)
    {
        if(currentGameState != null)
        {
            currentGameState.ExitGamestate();
        }

        switch (gameState)
        {
            case EGameStates.Hub:
                currentGameState = hubState;
                currentGameState.EnterGamestate();
                break;
            case EGameStates.Trench:
                currentGameState = trenchState;
                currentGameState.EnterGamestate();
                break;
            case EGameStates.ScoreAttackSaloon:
                break;
            case EGameStates.ScoreAttackStart:
                currentGameState = scoreAttackStartState;
                currentGameState.EnterGamestate();
                break;
            case EGameStates.ScoreAttackEnd:
                currentGameState = scoreAttackEndState;
                currentGameState.EnterGamestate();
                break;
        }
    }

    public void AddStateComponent(System.Type type)
    {
        Destroy(stateObject);
        stateObject = new GameObject();
        stateObject.name = "CurrentStateObject";
        stateObject.AddComponent(type);
    }
}
