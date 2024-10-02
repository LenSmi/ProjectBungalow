using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameStates
{
    Loading,
    MainMenu,
    Hub,
    Trench,
    ScoreAttackSaloon,
    ScoreAttackStart,
    ScoreAttackEnd,
    Debug
}

public class WorldStateManager : MonoBehaviour
{
    public EGameStates initialGameState;
    [HideInInspector]
    public EGameStates gameStates;
    public GameState currentGameState;
    public SceneChangeManager sceneChangeManager;
    public GameObject stateObject;
    public int debugInitialScene;

    public void Start()
    {
        TransitionToState(initialGameState);
    }

    public void TransitionToState(EGameStates gameState)
    {

        switch (gameState)
        {
            case EGameStates.MainMenu:
                ChangeState<MainMenuState>();
                break;
            case EGameStates.Hub:
                ChangeState<HubState>();
                break;
            case EGameStates.Trench:
                ChangeState<TrenchState>();
                break;
            case EGameStates.ScoreAttackSaloon:
                ChangeState<ScoreAttackSaloonState>();
                break;
            case EGameStates.ScoreAttackStart:
                ChangeState<ScoreAttackStartState>();
                break;
            case EGameStates.ScoreAttackEnd:
                ChangeState<ScoreAttackEndState>();
                break;
            case EGameStates.Debug:
                StartCoroutine(sceneChangeManager.IEDebugLoadGameScene(debugInitialScene));
                break;
        }

    }

    public void ChangeState<T>() where T: GameState
    {
        if (currentGameState != null)
        {
            currentGameState.ExitGamestate();
            Destroy(currentGameState);
        }

        currentGameState = stateObject.AddComponent<T>();
        currentGameState.EnterGamestate();
    }
}
