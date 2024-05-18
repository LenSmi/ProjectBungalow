using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{

    public float underwaterTime;
    public SceneChangeManager sceneChangeManager;
    public GameScenes initalGameScene;

    public void Start()
    {
#if UNITY_EDITOR
       StartCoroutine(sceneChangeManager.LoadGameScene(initalGameScene));
#endif
    }

    public void SetWorldState()
    {

    }
}
