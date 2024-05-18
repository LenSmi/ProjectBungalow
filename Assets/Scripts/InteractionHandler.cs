using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionInput
{
    LOADHUB,
    LOAD_TRENCHAREA_1
}

public class InteractionHandler : MonoBehaviour
{
    public KeyCode input;
    public InteractionInput interactionInput;
    public Collider obj_collider;
    private bool isColliding = false;
    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = FindObjectOfType<SceneChangeManager>();
    }

    public void Update()
    {
        if(isColliding && Input.GetKeyDown(input))
        {
            Interaction(interactionInput);
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



    public void Interaction(InteractionInput interactionInput)
    {
        if(sceneChangeManager == null)
        {
            sceneChangeManager = FindObjectOfType<SceneChangeManager>();
        }

        switch (interactionInput)
        {
            case InteractionInput.LOADHUB:
                Debug.Log("Loading Hub");
                StartCoroutine(sceneChangeManager.LoadGameScene(GameScenes.Scene_Hub));
                break;
            case InteractionInput.LOAD_TRENCHAREA_1:
                Debug.Log("Loading Trench Area 1");
                StartCoroutine(sceneChangeManager.LoadGameScene(GameScenes.Scene_TrenchArea1));
                break;
        }
    }
}
