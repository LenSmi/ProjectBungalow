using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubArmour : MonoBehaviour
{
    public float maxArmourAmount = 100;
    public float currentArmourAmount;

    public float invincibilityInterval;
    private float currentInvincibilityInterval = 0;

    public Action LoseArmourAction;
    public Action GainArmourAction;

    // Start is called before the first frame update
    void Start()
    {
        currentArmourAmount = maxArmourAmount;
        currentInvincibilityInterval = invincibilityInterval;
    }

    private void Update()
    {
        currentInvincibilityInterval -= Time.deltaTime;

        if(currentInvincibilityInterval <= 0 && GameManager.Instance().MinigameManager().IsStormActive())
        {
            LoseArmour(GameManager.Instance().MinigameManager().ToxicityDamage);
            currentInvincibilityInterval = invincibilityInterval;
        }
    }

    public void GainArmour(float amount)
    {

        currentArmourAmount += amount;
        GainArmourAction?.Invoke();
    }

    public void LoseArmour(float damage)
    {

        currentArmourAmount -= damage;
        LoseArmourAction?.Invoke();
    }
}
