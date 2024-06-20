using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerHandler : MonoBehaviour
{
    public Collider obj_collider;
    public InteractionResult interactionResult;
    private bool isColliding = false;
    private SceneChangeManager sceneChangeManager;
    private WorldStateManager worldStateManager;

    private void Start()
    {
        sceneChangeManager = GameManager.Instance().SceneChangeManager();
        worldStateManager = GameManager.Instance().WorldStateManager();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            isColliding = true;
            Interaction(interactionResult);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            isColliding = false;
        }
    }



    public void Interaction(InteractionResult interactionInput)
    {
        if (sceneChangeManager == null)
        {
            sceneChangeManager = GameManager.Instance().SceneChangeManager();
        }

        switch (interactionInput)
        {
            case InteractionResult.LOAD_SCORE_ATTACK_SALLOON:
                worldStateManager.TransitionToState(EGameStates.ScoreAttackSaloon);
                break;
            case InteractionResult.LOADHUB:
                Debug.Log("Loading Hub");
                worldStateManager.TransitionToState(EGameStates.Hub);
                break;
            case InteractionResult.LOAD_TRENCHAREA_1:
                Debug.Log("Loading Trench Area 1");
                worldStateManager.TransitionToState(EGameStates.Trench);
                break;
            case InteractionResult.LOAD_SCORE_ATTACK:
                Debug.Log("Loading Score Attack");
                worldStateManager.TransitionToState(EGameStates.ScoreAttackStart);
                break;
        }
    }
}
