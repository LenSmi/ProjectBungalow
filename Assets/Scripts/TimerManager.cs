using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    private WorldState worldState;
    private float timer;
    public Image fillImage;

    // Start is called before the first frame update
    void Start()
    {
        worldState = FindObjectOfType<WorldState>();
        timer = worldState.underwaterTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        float fraction = timer / worldState.underwaterTime;

        fillImage.fillAmount = fraction;

    }



}
