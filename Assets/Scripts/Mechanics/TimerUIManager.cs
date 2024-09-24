using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIManager : MonoBehaviour
{

    private MinigameManager minigameManager;
    private float timer;
    public Image fillImage;
    public bool isTicking = false;

    // Start is called before the first frame update
    void Start()
    {
        minigameManager = GameManager.Instance().MinigameManager();
        fillImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!minigameManager.IsStormActive())
        {
            fillImage.fillAmount = minigameManager.TimeUntilStorm / minigameManager.MaxTimeUntilStorm;
        }

    }


}
