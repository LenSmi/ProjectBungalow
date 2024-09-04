using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScenes
{
    //These need to have the same name as the scene file
    Scene_God,
    Scene_Hub,
    Scene_TrenchArea1,
    Scene_Score_Attack_Saloon,
    Scene_Score_Attack,
    Scene_Score_Attack_ScoreScreen
}

public class SceneChangeManager : MonoBehaviour
{
    public static Action IsLoadingDone;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        try
        {
            SceneManager.SetActiveScene(scene);
        }
        catch(Exception ex)
        {
            Debug.LogWarning("Could not set scene as active: " + SceneManager.GetActiveScene().ToString() + ", Exception: " + ex);
            throw;
        }


        Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);
    }

    void OnSceneUnloaded(Scene scene)
    {
        Resources.UnloadUnusedAssets();
    }

    public IEnumerator IELoadGameScene(GameScenes sceneToLoad)
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName(GameScenes.Scene_God.ToString()))
        {
            //Debug.Log("Active Scene is" + SceneManager.GetActiveScene().name);

            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            while (!asyncLoad.isDone)
            {
                // Here you can communicate the progress to the player
                // e.g., a loading bar
                yield return null;
            }

        }

        yield return StartCoroutine(LoadGameSceneAsync(sceneToLoad));
    }


    private IEnumerator LoadGameSceneAsync(GameScenes sceneToLoad)
    {

        if (!SceneManager.GetSceneByName(sceneToLoad.ToString()).isLoaded)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.ToString(), LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {
                // Here you can communicate the progress to the player
                // e.g., a loading bar
                yield return null;
            }
        }

        IsLoadingDone?.Invoke();
    }

    public IEnumerator IEDebugLoadGameScene(int index)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(GameScenes.Scene_God.ToString()))
        {
            Debug.Log("Active Scene is" + SceneManager.GetActiveScene().name);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        }

        
        yield return SceneManager.LoadSceneAsync(index,LoadSceneMode.Additive);
    }



}
