using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class QuotaUIManager : MonoBehaviour
{   
    private MinigameManager _minigameManager;
    public Image fillImage;
    public float quotaLerpValue;
    public GameObject exitPrompt;

    // Start is called before the first frame update
    void Start()
    {
        
        _minigameManager = GameManager.Instance().MinigameManager();

        _minigameManager.AddToDepositQuota += UpdateQuotaUI;
        _minigameManager.QuotaReached += UpdateExitPrompt;

       
        fillImage.fillAmount = _minigameManager.StartingQuota / _minigameManager.QuotaThreshold;
        exitPrompt.SetActive(false);
    }

    private void UpdateQuotaUI()
    {
        int additionValue = _minigameManager.QuotaDeposit;
        UIHelper.LerpAddFillImage(fillImage, additionValue, _minigameManager.QuotaThreshold, quotaLerpValue);
    }

    private void UpdateExitPrompt()
    {
        exitPrompt.SetActive(true);
    }

    private void OnDestroy()
    {
        _minigameManager.AddToDepositQuota -= UpdateQuotaUI;
        _minigameManager.QuotaReached -= UpdateExitPrompt;
    }
}
