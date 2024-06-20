using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionResult
{
    LOADHUB,
    LOAD_TRENCHAREA_1,
    LOAD_SCORE_ATTACK
}

public class InteractionHandler : MonoBehaviour
{
    public KeyCode input;
    public InteractionResult interactionResult;
    public Collider obj_collider;
    private bool isColliding = false;
    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = GameManager.Instance().SceneChangeManager();
    }

    public void Update()
    {
        if(isColliding && Input.GetKeyDown(input))
        {
            Interaction(interactionResult);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSub")
        {
            isColliding = true;
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
        if(sceneChangeManager == null)
        {
            sceneChangeManager = GameManager.Instance().SceneChangeManager();
        }

        switch (interactionInput)
        {
            case InteractionResult.LOADHUB:
                Debug.Log("Loading Hub");
                StartCoroutine(sceneChangeManager.LoadGameScene(GameScenes.Scene_Hub));
                break;
            case InteractionResult.LOAD_TRENCHAREA_1:
                Debug.Log("Loading Trench Area 1");
                StartCoroutine(sceneChangeManager.LoadGameScene(GameScenes.Scene_TrenchArea1));
                break;
        }
    }
}
