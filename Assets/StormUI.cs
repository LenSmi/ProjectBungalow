using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormUI : MonoBehaviour
{
    public GameObject stormOverlay;

    // Start is called before the first frame update
    void Start()
    {
        stormOverlay.SetActive(false);
        MinigameManager.StormStarted += UpdateStormUI;
    }

    void UpdateStormUI()
    {
        stormOverlay.SetActive(true);
    }

}
