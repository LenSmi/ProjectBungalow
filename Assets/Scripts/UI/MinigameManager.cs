using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public int ScoreAttack_TotalScore = 0;
    public int ScoreModifier = 1;
    public int StartingQuota;
    public int AddedQuota;
    public int CurrentQuota;
    public int QuotaThreshold;
    public int QuotaDeposit;
    public static Action AddToDepositQuota;
    public static Action QuotaReached;
    public static Action StormStarted;

    public bool IsGameActive = false;
    private bool IsStormCoroutineRunning = false;

    public float TimeUntilStorm;
    public float ToxicityDamage;

    private void Update()
    {
        if (IsGameActive)
        {
            TimeUntilStorm -= Time.deltaTime;
        }
    }

    public void CalculateTotalScore()
    {

    }

    public void UpdateQuota(int quantity)
    {
        AddedQuota += quantity;
        QuotaDeposit = AddedQuota;
    }

    public void DepositQuota()
    {
        CurrentQuota += QuotaDeposit;

        AddToDepositQuota?.Invoke();

        if(CheckOn())
        {
            CurrentQuota = 0;
            QuotaReached?.Invoke();
        }
        else
        {
            AddedQuota = 0;
        }

    }

    bool CheckOn() 
    {
        return CurrentQuota >= QuotaThreshold;
    }
    public IEnumerator StartGame()
    {
        Debug.Log("Starting Game");
        IsGameActive = true;

        while (IsGameActive)
        {


            if (IsStormActive() && !IsStormCoroutineRunning)
            {
                Debug.Log("Storm Active");
                StartCoroutine(StartStorm());
            }


            yield return null;
        }

        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame() 
    {
        IsGameActive = false;
        TimeUntilStorm = 0;
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackEnd);
        return null; 
    }  

    IEnumerator StartStorm()
    {
        StormStarted?.Invoke();
        IsStormCoroutineRunning = true;
        yield break;
    }

    public bool IsStormActive()
    {
        return TimeUntilStorm <= 0;
    }
}
