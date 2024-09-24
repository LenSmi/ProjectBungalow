using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreenManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        StartCoroutine(CalculateScores());
    }
    public IEnumerator CalculateScores()
    {
        PerformanceEvaluationData performanceData = GameManager.Instance().MinigameManager()._performanceData;
        finalScoreText.text = "Final Score: " + performanceData.TotalScore.ToString();

        yield return new WaitForSeconds(1f);
    }

    public void LoadSaloon()
    {
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackSaloon);
    }
}
