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
    public int CurrentQuota;
    public int QuotaThreshold;
    public int QuotaDeposit;
    public static Action AddToDepositQuota;

    public void CalculateTotalScore()
    {

    }

    public void UpdateQuota(int quantity)
    {
        CurrentQuota += quantity;
        QuotaDeposit = CurrentQuota;
    }

    public void DepositQuota()
    {
        Debug.Log("Called");
        AddToDepositQuota?.Invoke();
        CurrentQuota = 0;
    }
}
