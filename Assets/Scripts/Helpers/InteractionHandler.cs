using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionResult
{
    LOADHUB,
    LOAD_TRENCHAREA_1,
    LOAD_SCORE_ATTACK,
    END_SCORE_ATTACK,
    LOAD_SCORE_ATTACK_SALLOON
}

public class InteractionHandler : MonoBehaviour
{
    public KeyCode KeyInput;
    public InteractionResult InteractionResult;
    public Collider ObjectCollider;
    private bool _isColliding = false;
    private SceneChangeManager _sceneChangeManager;

    private void Start()
    {
        _sceneChangeManager = GameManager.Instance().SceneChangeManager();
    }

    public void Update()
    {
        if(_isColliding && Input.GetKeyDown(KeyInput))
        {
            Interaction(InteractionResult);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            _isColliding = true;
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
        if(_sceneChangeManager == null)
        {
            _sceneChangeManager = GameManager.Instance().SceneChangeManager();
        }

        switch (interactionInput)
        {
            case InteractionResult.LOADHUB:
                Debug.Log("Loading Hub");
                GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.Hub);
                break;
            case InteractionResult.LOAD_TRENCHAREA_1:
                Debug.Log("Loading Trench Area 1");
                GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.Trench);
                break;
        }
    }
}
