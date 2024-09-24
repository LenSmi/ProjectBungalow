using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [Header("Dependencies")]
    public PerformanceEvaluationData _performanceData;

    [Header("Values")]
    public int StartingQuota;
    private int CurrentQuota;
    public int QuotaThreshold;
    [HideInInspector] public int AddedQuota;
    public int QuotaDeposit;

    [Header("StormValues")]
    public float TimeUntilStorm;
    public float ToxicityDamage;

    public Action AddToDepositQuota;
    public Action QuotaReached;
    public static Action StormStarted;

    [HideInInspector] public bool IsGameActive = false;
    private bool IsStormCoroutineRunning = false;

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
        CurrentQuota = StartingQuota;
        AddedQuota = 0;
        QuotaDeposit = 0;

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

        if(CheckOn())
        {
            CurrentQuota = 0;
            AddedQuota = 0;
            QuotaReached?.Invoke();
        }
        else
        {
            AddedQuota = 0;
        }

        AddToDepositQuota?.Invoke();

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
        AddedQuota = 0;

        //Performance evaluation here?
        PerformanceEvaluationData performanceData = new PerformanceEvaluationData();
        performanceData.CalculateScore();
        _performanceData = performanceData;

        GameManager.Instance().CargoManager().AddDepositToCargoInventory();
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
