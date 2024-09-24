using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PerformanceEvaluationData", order = 1)]
public class PerformanceEvaluationData : ScriptableObject
{
    public bool IsAlive;
    public int AliveScore;
    public int TotalScore;
    public CargoData DepositCargoData;
    public Dictionary<ResourceItemData, int> ResourceScores = new Dictionary<ResourceItemData, int>();

    public void CalculateScore()
    {
        //Calculate score for each resource
        foreach(var resource in DepositCargoData.Resources) 
        { 
            ResourceItemData resourceItem = resource.Key;
            Debug.Log("ResourceItem: " + resourceItem);

            int resourceQuantity = resource.Value;
            Debug.Log("ResourceQuantity: " + resourceQuantity);

            int resourceScore = resourceQuantity * resourceItem.ScoreValue;
            Debug.Log("ResourceScore: " + resourceScore);

            if(ResourceScores.ContainsKey(resourceItem))
            {
                ResourceScores[resourceItem] += resourceScore;
                Debug.Log("Added" + ResourceScores[resourceItem] + ":" + resourceScore);
            }
            else
            {
                ResourceScores.Add(resourceItem, resourceScore);
                Debug.Log("Added" + resourceItem + ":" + resourceScore);
            }

            TotalScore += resourceScore;
        }

        //Has the player survived?
        if(IsAlive)
        {
            TotalScore += AliveScore;
        }
        //Total Score
        //Assign badge
    }

    public void Reset()
    {
        //Reset All Scores
        TotalScore = 0;
        ResourceScores.Clear();
    }

}
