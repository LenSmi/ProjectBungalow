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

    private int _startingQuota;
    private float _timeUntilStorm;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (IsGameActive)
        {
            TimeUntilStorm -= Time.deltaTime;
        }
    }

    private void Init()
    {
        _timeUntilStorm = TimeUntilStorm;
        _startingQuota = StartingQuota;

    }

    private void Reset()
    {
        TimeUntilStorm = _timeUntilStorm;
        StartingQuota = _startingQuota;
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

    public bool IsStormActive()
    {
        return TimeUntilStorm <= 0;
    }

    public IEnumerator EndGame() 
    {
        IsGameActive = false;
        IsStormCoroutineRunning = false;
        TimeUntilStorm = 0;
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackEnd);
        Reset();
        return null; 
    }  

    IEnumerator StartStorm()
    {
        StormStarted?.Invoke();
        IsStormCoroutineRunning = true;
        yield break;
    }
}
