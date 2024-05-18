using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScenes
{
    Scene_God,
    Scene_Hub,
    Scene_TrenchArea1
}

public class SceneChangeManager : MonoBehaviour
{
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
        catch
        {
            Debug.LogWarning("Could not set scene as active: " + SceneManager.GetActiveScene().ToString());
        }


        Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);
    }

    void OnSceneUnloaded(Scene scene)
    {
        Resources.UnloadUnusedAssets();
    }

    public IEnumerator LoadGameScene(GameScenes sceneToLoad)
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName(GameScenes.Scene_God.ToString()))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
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
                Debug.Log("Loading: " + sceneToLoad.ToString());
                yield return null;
            }
        }

   
    }

    




}
