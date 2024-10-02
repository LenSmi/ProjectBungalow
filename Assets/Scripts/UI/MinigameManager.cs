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
    public CustomRenderSettings toxicStormRenderSettings;
    private CustomRenderSettings baseStormRenderSettings;
    public float TimeUntilStorm;
    public float MaxTimeUntilStorm;
    public float ToxicityDamage;
    public Color baseStormColour;
    public Color toxicStormColour;
    private float originalDensity;
    public float baseStormDensity;

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

        baseStormRenderSettings = RenderSettingHelper.GetRenderSettings();

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

        _performanceData.Reset();
        _performanceData.CalculateScore();

        GameManager.Instance().CargoManager().AddDepositToCargoInventory();
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackEnd);
        Reset();
        return null; 
    }  

    IEnumerator StartStorm()
    {
        StormStarted?.Invoke();
        StartCoroutine(
            SetStormEffects(toxicStormRenderSettings.fogEndDistance, toxicStormRenderSettings.fogSettingLerpSpeed)
            ); 
        IsStormCoroutineRunning = true;
        yield break;
    }

    private IEnumerator SetStormEffects(float targetFogEndDistance, float duration)
    {
        float initialFogEndDistance = RenderSettings.fogEndDistance;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            toxicStormRenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance, targetFogEndDistance, t);
            RenderSettingHelper.SetRenderSettings(toxicStormRenderSettings);
            yield return null;
        }

        RenderSettingHelper.SetRenderSettings(toxicStormRenderSettings);
    }

    private void OnDisable()
    {
        RenderSettingHelper.SetRenderSettings(baseStormRenderSettings);
    }


}
