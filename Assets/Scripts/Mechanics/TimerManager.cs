using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    private WorldState worldState;
    private float timer;
    public Image fillImage;
    public bool isTicking = false;

    // Start is called before the first frame update
    void Start()
    {
        worldState = FindObjectOfType<WorldState>();
        timer = worldState.underwaterTime;
        isTicking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTicking)
        {
            timer -= Time.deltaTime;

            float fraction = timer / worldState.underwaterTime;

            fillImage.fillAmount = fraction;
        }

    }

    public void ResetTimer()
    {
        timer = worldState.underwaterTime;
        isTicking = true;
    }



}
