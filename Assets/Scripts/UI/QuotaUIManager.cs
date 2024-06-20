using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class QuotaUIManager : MonoBehaviour
{
    private MinigameManager minigameManager;
    public Image fillImage;
    public float quotaLerpValue;

    // Start is called before the first frame update
    void Start()
    {
        minigameManager = GameManager.Instance().MinigameManager();
        MinigameManager.AddToDepositQuota += UpdateQuotaUI;
        fillImage.fillAmount = minigameManager.StartingQuota / minigameManager.QuotaThreshold;
    }

    private void UpdateQuotaUI()
    {
        int additionValue = minigameManager.QuotaDeposit;
        UIHelper.LerpAddFillImage(fillImage, additionValue, minigameManager.QuotaThreshold, quotaLerpValue);
    }
}
