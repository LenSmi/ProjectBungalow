using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StormUI : MonoBehaviour
{
    public GameObject stormFX;

    // Start is called before the first frame update
    void Start()
    {
        stormFX.SetActive(false);
        MinigameManager.StormStarted += UpdateStormUI;
    }

    void UpdateStormUI()
    {
        stormFX.SetActive(true);
    }

    private void OnDestroy()
    {
        MinigameManager.StormStarted -= UpdateStormUI;
    }

}
