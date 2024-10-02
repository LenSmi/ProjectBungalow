using DG.Tweening;
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

        scoreText.text = "";
        var tempText = new TextMeshProUGUI();

        foreach (var scores in performanceData.ResourceScores)
        {
            tempText.text += $"{scores.Key.resourceType}: {scores.Value}\n";
            performanceData.TotalScore += performanceData.TotalScore;
        }

        scoreText.DOText(tempText.text, 1f);

        finalScoreText.text = $"Final Score: {performanceData.TotalScore}";

        yield return new WaitForSeconds(1f);
    }

    public void LoadSaloon()
    {
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackSaloon);
    }
}
