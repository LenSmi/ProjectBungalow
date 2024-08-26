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
    public GameObject exitPrompt;

    // Start is called before the first frame update
    void Start()
    {
        MinigameManager.AddToDepositQuota += UpdateQuotaUI;
        MinigameManager.QuotaReached += UpdateExitPrompt;

        minigameManager = GameManager.Instance().MinigameManager();
        fillImage.fillAmount = minigameManager.StartingQuota / minigameManager.QuotaThreshold;
        exitPrompt.SetActive(false);
    }

    private void UpdateQuotaUI()
    {
        int additionValue = minigameManager.QuotaDeposit;
        UIHelper.LerpAddFillImage(fillImage, additionValue, minigameManager.QuotaThreshold, quotaLerpValue);
    }

    private void UpdateExitPrompt()
    {
        exitPrompt.SetActive(true);
    }
}
