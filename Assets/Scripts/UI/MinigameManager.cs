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
        Debug.Log("Called");
        AddToDepositQuota?.Invoke();

        if(CurrentQuota >= QuotaThreshold)
        {
            GameManager.Instance().WorldStateManager().TransitionToState(WorldStateManager.scoreAttackEndState);
            CurrentQuota = 0;
        }
        else
        {
            AddedQuota = 0;
        }

    }
}
