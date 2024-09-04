using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerHandler : MonoBehaviour
{
    [SerializeField]
    private Collider ObjectCollider;
    public InteractionResult InteractionResult;
    private bool _isColliding = false;
    private SceneChangeManager _sceneChangeManager;
    private WorldStateManager _worldStateManager;

    private void Start()
    {
        _sceneChangeManager = GameManager.Instance().SceneChangeManager();
        _worldStateManager = GameManager.Instance().WorldStateManager();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            _isColliding = true;
            Interaction(InteractionResult);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            _isColliding = false;
        }
    }



    public void Interaction(InteractionResult interactionInput)
    {
        if (_sceneChangeManager == null)
        {
            _sceneChangeManager = GameManager.Instance().SceneChangeManager();
        }

        switch (interactionInput)
        {
            case InteractionResult.END_SCORE_ATTACK:
                MinigameManager manager = GameManager.Instance().MinigameManager();
                StartCoroutine(manager.EndGame());
                break;
            case InteractionResult.LOAD_SCORE_ATTACK_SALLOON:
                _worldStateManager.TransitionToState(EGameStates.ScoreAttackSaloon);
                break;
            case InteractionResult.LOADHUB:
                Debug.Log("Loading Hub");
                _worldStateManager.TransitionToState(EGameStates.Hub);
                break;
            case InteractionResult.LOAD_TRENCHAREA_1:
                Debug.Log("Loading Trench Area 1");
                _worldStateManager.TransitionToState(EGameStates.Trench);
                break;
            case InteractionResult.LOAD_SCORE_ATTACK:
                Debug.Log("Loading Score Attack");
                _worldStateManager.TransitionToState(EGameStates.ScoreAttackStart);
                break;
        }
    }
}
