using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{

    public float durabilityLoss = 30;
    public float miningTickInterval;
    public float timer = 0.0f;

    public bool canMine;
    public bool ticking;


    // Start is called before the first frame update
    void Start()
    {
        canMine = true;
        ticking = true;
    }

    // Update is called once per frame
    void Update()
    {
        MiningTick();
    }

    public void MiningTick()
    {

        if (ticking)
        {

            timer += Time.deltaTime;

            if (timer > miningTickInterval)
            {
                ticking = false;
                canMine = true;
            }

        }

    }

    public void Reset()
    {
        ticking = true;
        canMine = false;
        timer = 0;
    }
}
